using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Trabajo
{
    public int Idtrabajo { get; set; }

    public string? Descripcion { get; set; }

    public int? Puntos { get; set; }

    public virtual ICollection<OrdenTrabajo> OrdenTrabajos { get; set; } = new List<OrdenTrabajo>();
}
