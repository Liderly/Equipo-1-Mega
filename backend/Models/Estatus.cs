using System;
using System.Collections.Generic;

namespace Backend_HackathonMega.Models;

public partial class Estatus
{
    public int EstatusId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<OrdenesTrabajo> OrdenesTrabajos { get; set; } = new List<OrdenesTrabajo>();
}
