using System;
using System.Collections.Generic;

namespace simple_crud.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
