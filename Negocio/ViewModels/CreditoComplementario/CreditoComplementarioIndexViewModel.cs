using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.CreditoComplementario
{
    public class CreditoCompementarioIndexViewModel
    {

        public List<CreditoCompementarioIndexListadoViewModel> Listado { get; set; }

        public CreditoCompementarioIndexViewModel()
        {
            Listado = new List<CreditoCompementarioIndexListadoViewModel>();
        }

    }

    public class CreditoCompementarioIndexListadoViewModel
    {
        public string IDEncriptado { get; set; }

        public int? CC_IDCreditoComplementario { get; set; }

        public int? CC_IDCreditoInicial { get; set; }

        [Display(Name = "Folio Solicitud")]
        public string CC_FolioSolicitud { get; set; }

        [Display(Name = "Folio Credito Inicial")]
        public string CI_FolioSolicitud { get; set; }

        [Display(Name = "CURP")]
        public string CI_CURP { get; set; }

        [Display(Name = "Nombre del Ciudadano")]
        public string NombreCiudadano { get; set; }

        [Display(Name = "Fecha de solicitud")]
        public String CC_FechaSolicitud { get; set; }

        [Display(Name = "Dictamen Social")]
        public string[] ImgDS { get; set; }

        [Display(Name = "Dictamen Tecnico")]
        public string[] ImgDT { get; set; }

        [Display(Name = "Dictamen Juridico")]
        public string[] ImgDJ { get; set; }

        [Display(Name = "Dictamen Financiero")]
        public string[] ImgDF { get; set; }
    }
}
