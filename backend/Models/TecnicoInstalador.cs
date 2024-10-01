using System;
using System.Collections.Generic;

namespace Backend_HackathonMega.Models;

public partial class TecnicoInstalador
{
    public int TecnicoInstaladorId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string NumTecnico { get; set; } = null!;

    public int CuadrillaId { get; set; }

    public virtual Cuadrilla Cuadrilla { get; set; } = null!;
}
