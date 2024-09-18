using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Estatus
{
    public int Idestatus { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<OrdenTrabajo> OrdenTrabajos { get; set; } = new List<OrdenTrabajo>();
}
