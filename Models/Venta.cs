using System;
using System.Collections.Generic;

namespace simple_crud.Models;

public partial class Venta
{
    public int Id { get; set; }

    public int? ClienteId { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
