using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Cuadrilla
{
    public int Idcuadrilla { get; set; }

    public int? NumCuadrilla { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
