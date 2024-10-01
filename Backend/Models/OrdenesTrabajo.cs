using System;
using System.Collections.Generic;

namespace Backend_HackathonMega.Models;

public partial class OrdenesTrabajo
{
    public int OrdenTrabajoId { get; set; }

    public int ClienteId { get; set; }

    public int CuadrillaId { get; set; }

    public int TrabajoId { get; set; }

    public int ServicioId { get; set; }

    public int EstatusId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaFinalizacion { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Cuadrilla Cuadrilla { get; set; } = null!;

    public virtual Estatus Estatus { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Trabajo Trabajo { get; set; } = null!;
}
