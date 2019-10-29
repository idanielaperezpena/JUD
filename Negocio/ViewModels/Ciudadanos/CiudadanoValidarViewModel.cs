using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.Ciudadanos
{
   public class CiudadanoValidarViewModel
    {
        [CustomRequired]
        [Display(Name = "CURP o Nombre Completo del Ciudadano *")]
        public string CadenaBusqueda { get; set; }

        public List<CiudadanosIndexListadoViewModel> Listado { get; set; }

        public CiudadanoValidarViewModel()
        {
            Listado = new List<CiudadanosIndexListadoViewModel>();
        }

    }
}
