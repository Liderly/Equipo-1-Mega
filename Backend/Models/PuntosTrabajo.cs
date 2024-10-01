using System;
using System.Collections.Generic;

namespace Backend_HackathonMega.Models;

public partial class PuntosTrabajo
{
    public int PuntosTrabajoId { get; set; }

    public int Valor { get; set; }

    public virtual ICollection<Trabajo> Trabajos { get; set; } = new List<Trabajo>();
}
