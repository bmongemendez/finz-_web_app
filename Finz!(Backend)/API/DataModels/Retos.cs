using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.DataModels
{
    public partial class Retos
    {
        public int IdReto { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
