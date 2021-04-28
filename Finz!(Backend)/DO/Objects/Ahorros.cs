using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DO.Objects
{
    public partial class Ahorros
    {
        public int IdAhorros { get; set; }
        public int AhorrosAcutales { get; set; }
        public String IdUsuario { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
