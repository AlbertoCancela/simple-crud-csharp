using System;
using System.Collections.Generic;

namespace simple_crud.Models;

public partial class UsersWebService
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Age { get; set; }

    public DateTime CreatedAt { get; set; }
}
