using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.Ciudadanos
{
    public class CiudadanoInformacionViewModel
    {

        public CiudadanoDatosPersonalesViewModel ciudadano;

        public List<CiudadanoInformacionListadoViewModel> Listado { get; set; }

        public CiudadanoInformacionViewModel()
        {
            Listado = new List<CiudadanoInformacionListadoViewModel>();
            ciudadano = new CiudadanoDatosPersonalesViewModel();
        }
    }

    public class CiudadanoInformacionListadoViewModel
    {
        public int? ID { get; set; }

        [Display(Name = "Folio Solicitud")]
        public string FolioSolicitud { get; set; }

        [Display(Name = "Tipo de Solicitud")]
        public string TipoSolicitud { get; set; }

        [Display(Name = "Fecha de solicitud")]
        public String FechaSolicitud { get; set; }

        [Display(Name = "Estatus")]
        public string Estatus { get; set; }
    }
}
