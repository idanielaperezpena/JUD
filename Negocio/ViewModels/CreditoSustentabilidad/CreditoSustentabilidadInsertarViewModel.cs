using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.CreditoSustentabilidad
{
   public  class CreditoSustentabilidadInsertarViewModel
    {
        public int? CS_IDCreditoSustentabilidad { get; set; }
        public int CS_IDCreditoInicial { get; set; }
        [CustomRequired]
        [Display(Name = "Folio Solicitud *")]
        [RegularExpression("^Cs-[0-9]{4}$", ErrorMessage = "El formato del folio no es válido")]
        public string CS_FolioSolicitud { get; set; }
      
        public DateTime CS_FechaCaptura { get; set; }

        [CustomRequired]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Solicitud *")]
        public DateTime CS_FechaSolicitud { get; set; }
    }
}
