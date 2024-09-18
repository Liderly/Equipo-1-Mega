using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Empleado
{
    public int Idempleado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? NumEmpleado { get; set; }

    public int? Idcuadrilla { get; set; }

    public virtual Cuadrilla? IdcuadrillaNavigation { get; set; }

    public virtual ICollection<OrdenTrabajo> OrdenTrabajos { get; set; } = new List<OrdenTrabajo>();
}
