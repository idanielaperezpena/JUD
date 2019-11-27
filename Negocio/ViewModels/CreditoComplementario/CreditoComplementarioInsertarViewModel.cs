using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.CreditoComplementario

{
   public class CreditoComplementarioInsertarViewModel
    {
        public int? CC_IDCreditoComplementario { get; set; }
        public int CC_IDCreditoInicial { get; set; }
        [CustomRequired]
        [Display(Name = "Folio Solicitud *")]
        public string CC_FolioSolicitud { get; set; }
       
        public DateTime CC_FechaCaptura { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha de Solicitud *")]
        public DateTime CC_FechaSolicitud { get; set; }

        [Display(Name = "No. de Sesión del Comité *")]
        public int? CC_NoSesionComite { get; set; }

        [Display(Name = "ID de Mejoramiento *")]
        public int? CC_IDMejoramiento { get; set; }

        [CustomRequired]
        [Display(Name = "Ingreso *")]
        public double CC_Ingreso { get; set; }
    }
}
