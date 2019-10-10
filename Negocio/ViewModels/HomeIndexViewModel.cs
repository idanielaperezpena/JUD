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
        [StringLength(5,ErrorMessage = "The First Name must be less than {1} characters.")]
        [Display(Name = "Usuario")]
        public string USU_Usuario { get; set; }



        [CustomRequired]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string USU_Password { get; set; }
    }
}
