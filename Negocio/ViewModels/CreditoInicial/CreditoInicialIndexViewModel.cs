using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.CreditoInicial
{
    public class CreditoInicialIndexViewModel
    {

        public List<CreditoInicialIndexListadoViewModel> Listado { get; set; }

        public CreditoInicialIndexViewModel()
        {
            Listado = new List<CreditoInicialIndexListadoViewModel>();
        }

    }

    public class CreditoInicialIndexListadoViewModel
    {
        public string IDEncriptado { get; set; }

        public int? CI_ID { get; set; }

        [Display(Name = "Folio Solicitud")]
        public string CI_FolioSolicitud { get; set; }

        [Display(Name = "CURP")]
        public string CURPCiudadano { get; set; }

        [Display(Name = "Nombre del Ciudadano")]
        public string NombreCiudadano { get; set; }

        [Display(Name = "Fecha de solicitud")]
        public String CI_FechaSolicitud { get; set; }

        [Display(Name = "Sección Electoral")]
        public int? CI_IDSeccionElectoral { get; set; }

        [Display(Name = "Dictamen Social")]
        public string[] ImgDS { get; set; }

        [Display(Name = "Dictamen Técnico")]
        public string[] ImgDT { get; set; }

        [Display(Name = "Dictamen Jurídico")]
        public string[] ImgDJ { get; set; }

        [Display(Name = "Dictamen Financiero")]
        public string[] ImgDF { get; set; }
    }
}
