using System;
using System.Collections.Generic;

namespace Backend_HackathonMega.Models;

public partial class Trabajo
{
    public int TrabajoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? PuntosTrabajoId { get; set; }

    public virtual ICollection<OrdenesTrabajo> OrdenesTrabajos { get; set; } = new List<OrdenesTrabajo>();

    public virtual PuntosTrabajo? PuntosTrabajo { get; set; }
}
