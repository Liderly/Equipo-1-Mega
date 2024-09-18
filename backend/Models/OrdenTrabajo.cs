using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class OrdenTrabajo
{
    public int Idorden { get; set; }

    public int? Idsuscriptor { get; set; }

    public int? Idempleado { get; set; }

    public int? Idtrabajo { get; set; }

    public int? Idservicio { get; set; }

    public int? Idestatus { get; set; }

    public DateTime? FechaCreación { get; set; }

    public virtual Empleado? IdempleadoNavigation { get; set; }

    public virtual Estatus? IdestatusNavigation { get; set; }

    public virtual Servicio? IdservicioNavigation { get; set; }

    public virtual Suscriptor? IdsuscriptorNavigation { get; set; }

    public virtual Trabajo? IdtrabajoNavigation { get; set; }
}
