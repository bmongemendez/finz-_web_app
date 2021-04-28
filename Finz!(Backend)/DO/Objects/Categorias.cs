using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DO.Objects
{
    public partial class Categorias
    {
        public Categorias()
        {
            Ahorros = new HashSet<Ahorros>();
            Gastos = new HashSet<Gastos>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Ahorros> Ahorros { get; set; }
        public virtual ICollection<Gastos> Gastos { get; set; }
    }
}
