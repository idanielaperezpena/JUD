using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.ModificacionesCredito
{
    class ModificacionesCreditoInsertarViewModel
    {
        public int? MC_IDModificacionesCredito { get; set; }
        public int MC_IDCreditoInicial { get; set; }

        [CustomRequired] 
        [Display(Name = "Folio Solicitud *")]
        public string MC_FolioSolicitud { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MC_FechaCaptura { get; set; }

        [CustomRequired]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Solicitud *")]
        public DateTime MC_FechaSolicitud { get; set; }

        [CustomRequired]
        [Display(Name = "Problemática*")]
        public int MC_IDProblema { get; set; }

        public int MC_IDCiudadano { get; set; }

        [CustomRequired]
        [Display(Name = "Procedencia *")]
        public int MC_Procedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Tipo de Solicitante*")]
        public int MC_IDTipoTramite { get; set; }

        [CustomRequired]
        [Display(Name = "Ingreso*")]
        public float MC_Ingreso { get; set; }

        public ICustomSelectList<Entidades.Catalogos>Problematica { get; set; }
        public ICustomSelectList<Entidades.Catalogos>TipoTramite { get; set; }

    }
}
