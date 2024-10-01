using System;
using System.Collections.Generic;

namespace Backend_HackathonMega.Models;

public partial class RangoPunto
{
    public int RangoInicio { get; set; }

    public int? RangoFin { get; set; }

    public int PagoPuntosId { get; set; }

    public virtual PagoPunto PagoPuntos { get; set; } = null!;
}
