using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Finz__Frontend_.Models
{
    public partial class Gastos
    {
        public int IdGastos { get; set; }
        [Display(Name = "Expenses")]

        public int Gastos1 { get; set; }
        [Display(Name = "Start Date")]

        public DateTime FechaInicio { get; set; }
        [Display(Name = "End Date")]

        public DateTime FechaFin { get; set; }
        [Display(Name = "Category")]

        public int IdCategoria { get; set; }
        [Display(Name = "User")]

        public string IdUsuario { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
