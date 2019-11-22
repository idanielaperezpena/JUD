using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.ModificacionesCredito
{
    public class ModificacionesCreditoIndexViewModel
    {

        public List<ModificacionesCreditoIndexListadoViewModel> Listado { get; set; }
        public List<ModificacionesCreditoIndexCIListadoViewModel> ListadoCI { get; set; }

        
        public ModificacionesCreditoIndexViewModel()
        {
            Listado = new List<ModificacionesCreditoIndexListadoViewModel>();
            ListadoCI = new List<ModificacionesCreditoIndexCIListadoViewModel>();

        }

    }

    public class ModificacionesCreditoIndexListadoViewModel
    {

        public int? MC_IDModificacionesCredito { get; set; }
        public int MC_IDCreditoInicial { get; set; }

        [Display(Name = "Folio Solicitud")]
        public string MC_FolioSolicitud { get; set; }

        [Display(Name = "Folio Solicitud Crédito Inicial")]
        public string CI_FolioSolicitud { get; set; }

        [Display(Name = "CURP")]
        public string CI_CURP { get; set; }

        [Display(Name = "Nombre del Ciudadano")]
        public string NombreCiudadano { get; set; }

        [Display(Name = "Fecha de solicitud")]
        public string MC_FechaSolicitud { get; set; }
               
        [Display(Name = "Dictamen Social")]
        public string[] ImgDS { get; set; }

        [Display(Name = "Dictamen Tecnico")]
        public string[] ImgDT { get; set; }

        [Display(Name = "Dictamen Juridico")]
        public string[] ImgDJ { get; set; }

        [Display(Name = "Dictamen Financiero")]
        public string[] ImgDF { get; set; }
    }

    public class ModificacionesCreditoIndexCIListadoViewModel
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

        [Display(Name = "Seccion Electoral")]
        public int? CI_IDSeccionElectoral { get; set; }
        public string IDEncriptado { get; internal set; }
    }
}
