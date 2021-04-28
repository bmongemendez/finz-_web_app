using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DO.Objects
{
    public partial class Usuario
    {
        public Usuario()
        {
            Ahorros = new HashSet<Ahorros>();
            Dinero = new HashSet<Dinero>();
            Gastos = new HashSet<Gastos>();
            GastosFijos = new HashSet<GastosFijos>();
            Retos = new HashSet<Retos>();
        }

        public int IdUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Ahorros> Ahorros { get; set; }
        public virtual ICollection<Dinero> Dinero { get; set; }
        public virtual ICollection<Gastos> Gastos { get; set; }
        public virtual ICollection<GastosFijos> GastosFijos { get; set; }
        public virtual ICollection<Retos> Retos { get; set; }
    }
}
