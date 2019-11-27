using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.CreditoComplementario
{
    public class CreditoComplementarioIndexViewModel
    {

        public List<CreditoComplementarioIndexListadoViewModel> Listado { get; set; }

        public List<CreditoComplementarioIndexCIListadoViewModel> ListadoCI { get; set; }


        public CreditoComplementarioIndexViewModel()
        {
            Listado = new List<CreditoComplementarioIndexListadoViewModel>();
            ListadoCI = new List<CreditoComplementarioIndexCIListadoViewModel>();
        }

    }

    public class CreditoComplementarioIndexListadoViewModel
    {
        

        public int? CC_IDCreditoComplementario { get; set; }

        public int CC_IDCreditoInicial { get; set; }

        [Display(Name = "Folio Solicitud")]
        public string CC_FolioSolicitud { get; set; }

        [Display(Name = "Folio Crédito Inicial")]
        public string CI_FolioSolicitud { get; set; }

        [Display(Name = "CURP")]
        public string CI_CURP { get; set; }

        [Display(Name = "Nombre del Ciudadano")]
        public string NombreCiudadano { get; set; }

        [Display(Name = "Fecha de solicitud")]
        public String CC_FechaSolicitud { get; set; }

        [Display(Name = "Dictamen Social")]
        public string[] ImgDS { get; set; }

        [Display(Name = "Dictamen Técnico")]
        public string[] ImgDT { get; set; }

        [Display(Name = "Dictamen Jurídico")]
        public string[] ImgDJ { get; set; }

        [Display(Name = "Dictamen Financiero")]
        public string[] ImgDF { get; set; }
    }

    public class CreditoComplementarioIndexCIListadoViewModel
    {

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
        public string IDEncriptado { get; internal set; }
    }
}
