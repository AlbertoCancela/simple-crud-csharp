using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore;

namespace simple_crud.Models;

public partial class QueryDummiesContext : DbContext
{
    public QueryDummiesContext(DbContextOptions<QueryDummiesContext> options)
        : base(options) { }

    public virtual DbSet<Users> USERS { get; set; } = null!;
    public virtual DbSet<ContactData> CONTACT_DATA { get; set; } = null!;
    public virtual DbSet<AdditionalData> ADDITIONAL_DATA { get; set; } = null!; 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>(entity =>
        {
            entity.ToTable("USERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.LastName).HasColumnName("LAST_NAME");
            entity.Property(e => e.DateCreation).HasColumnName("DATE_CREATION");

            entity.HasMany(e => e.CONTACT_DATA)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.ADDITIONAL_DATA)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ContactData>(entity =>
        {
            entity.ToTable("CONTACT_DATA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");
            entity.Property(e => e.PhoneNumber).HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
        });

        modelBuilder.Entity<AdditionalData>(entity =>
        {
            entity.ToTable("ADDITIONAL_DATA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");
            entity.Property(e => e.UserData).HasColumnName("USER_DATA");
        });
    }
}

