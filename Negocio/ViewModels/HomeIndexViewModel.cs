using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels
{
    public class HomeIndexViewModel
    {
        [CustomRequired]
        [Display(Name = "Usuario Dominio *")]
        public string USU_Usuario { get; set; }

        [CustomRequired]
        [Display(Name = "Contraseña *")]
        [DataType(DataType.Password)]
        public string USU_Password { get; set; }
    }
}
