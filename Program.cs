
using MySqlConnector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple_crud.Models;
//using simple_crud.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<QueryDummiesContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});

var app = builder.Build();
app.UseHttpsRedirection();

//Obtener todos los usuarios
app.MapGet("/api/users", async (QueryDummiesContext db) =>
{
    var users = await db.USERS
        .Include(u => u.CONTACT_DATA)
        .Include(u => u.ADDITIONAL_DATA)
        .ToListAsync();

    return Results.Ok(users);
}).WithName("GetAllUsers");

//Obtener usuarios por ID
app.MapGet("/api/users/{id}", async (int id, QueryDummiesContext db) =>
{
    var user = await db.USERS
        .Include(u => u.CONTACT_DATA)
        .Include(u => u.ADDITIONAL_DATA)
        .FirstOrDefaultAsync(u => u.Id == id);

    return user is not null ? Results.Ok(user) : Results.NotFound();
}).WithName("GetUserById");

//Insertar un usuario
app.MapPost("/api/users", async (UserRequest request, QueryDummiesContext db) =>
{
    var user = new Users
    {
        Name = request.Name,
        LastName = request.LastName,
        DateCreation = DateTime.UtcNow
    };

    db.USERS.Add(user);
    await db.SaveChangesAsync();

    var contact = new ContactData
    {
        UserId = user.Id,
        PhoneNumber = request.PhoneNumber,
        Email = request.Email
    };
    db.CONTACT_DATA.Add(contact);

    var additional = new AdditionalData
    {
        UserId = user.Id,
        UserData = request.Data
    };
    db.ADDITIONAL_DATA.Add(additional);

    await db.SaveChangesAsync();

    return Results.Created($"/api/users/{user.Id}", user);
}).WithName("CreateUser");

//Actualizar un usuario
app.MapPut("/api/users/{id}", async (int id, UserRequest request, QueryDummiesContext db) =>
{
    var user = await db.USERS.FindAsync(id);
    if (user is null) return Results.NotFound();

    user.Name = request.Name;
    user.LastName = request.LastName;
    
    var contactData = await db.CONTACT_DATA.FirstOrDefaultAsync(c => c.UserId == id);
    if (contactData is not null)
    {
        contactData.PhoneNumber = request.PhoneNumber;
        contactData.Email = request.Email;
    }

    var additionalData = await db.ADDITIONAL_DATA.FirstOrDefaultAsync(a => a.UserId == id);
    if (additionalData is not null)
    {
       additionalData.UserData = request.Data ?? string.Empty;
    }


    await db.SaveChangesAsync();
    return Results.NoContent();
}).WithName("UpdateUser");

// Eliminar un usuario
app.MapDelete("/api/users/{id}", async (int id, QueryDummiesContext db) =>
{
    var user = await db.USERS
        .Include(u => u.CONTACT_DATA)
        .Include(u => u.ADDITIONAL_DATA)
        .FirstOrDefaultAsync(u => u.Id == id);

    if (user is null) return Results.NotFound();

    db.CONTACT_DATA.RemoveRange(user.CONTACT_DATA);
    db.ADDITIONAL_DATA.RemoveRange(user.ADDITIONAL_DATA); 
    db.USERS.Remove(user); 
    await db.SaveChangesAsync();

    return Results.NoContent();
}).WithName("DeleteUser");

app.Run();



app.Run();

