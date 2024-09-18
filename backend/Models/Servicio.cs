using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Servicio
{
    public int Idservicio { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<OrdenTrabajo> OrdenTrabajos { get; set; } = new List<OrdenTrabajo>();
}
