using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.CreditoSustentabilidad
{
    class CreditoSustentabilidadInsertarViewModel
    {
        public int? CS_IDCreditoSustentabilidad { get; set; }
        public int CS_IDCreditoInicial { get; set; }
        [CustomRequired]
        [Display(Name = "Folio Solicitud *")]
        public string CS_FolioSolicitud { get; set; }
      
        public DateTime CS_FechaCaptura { get; set; }
        [CustomRequired]
        [Display(Name = "Fecha de Solicitud *")]
        public DateTime CS_FechaSolicitud { get; set; }
    }
}
