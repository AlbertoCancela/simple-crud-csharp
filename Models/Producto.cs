using System;
using System.Collections.Generic;

namespace simple_crud.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
