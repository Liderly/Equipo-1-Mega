using System;
using System.Collections.Generic;

namespace Backend_HackathonMega.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public int NumCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public string? Telefono { get; set; }

    public virtual ICollection<OrdenesTrabajo> OrdenesTrabajos { get; set; } = new List<OrdenesTrabajo>();
}
