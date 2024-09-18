using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Suscriptor
{
    public int Idsuscriptor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Domicilio { get; set; }

    public string? Correo { get; set; }

    public int? Telefono { get; set; }

    public virtual ICollection<OrdenTrabajo> OrdenTrabajos { get; set; } = new List<OrdenTrabajo>();
}
