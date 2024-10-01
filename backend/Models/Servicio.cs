using System;
using System.Collections.Generic;

namespace Backend_HackathonMega.Models;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string NombreServicio { get; set; } = null!;

    public virtual ICollection<OrdenesTrabajo> OrdenesTrabajos { get; set; } = new List<OrdenesTrabajo>();
}
