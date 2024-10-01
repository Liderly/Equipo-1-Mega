using System;
using System.Collections.Generic;

namespace Backend_HackathonMega.Models;

public partial class Cuadrilla
{
    public int CuadrillaId { get; set; }

    public int NumCuadrilla { get; set; }

    public virtual ICollection<OrdenesTrabajo> OrdenesTrabajos { get; set; } = new List<OrdenesTrabajo>();

    public virtual ICollection<TecnicoInstalador> TecnicoInstaladors { get; set; } = new List<TecnicoInstalador>();
}
