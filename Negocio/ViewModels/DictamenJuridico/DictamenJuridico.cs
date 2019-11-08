using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.DictamenJuridico
{
    class DictamenJuridico
    {
        public int? IDDIctamenJuridico { get; set; }
        public int IDCreditoInicial { get; set; }
        [CustomRequired]
        [Display(Name = "Tipo de Propiedad *")]
        public int IDPropiedad { get; set; }

        [CustomRequired]
        [Display(Name = "Tipo de Posesión *")]
        public int IDPosesion { get; set; }

        [CustomRequired]
        [Display(Name = "No de Documento de Propiedad*")]
        public string NoDocumentoPropiedad { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha del Documento *")]
        public DateTime FechaDocumento { get; set; }

        [CustomRequired]
        [Display(Name = "¿Se requiere anuencia? *")]
        public bool Anuencia { get; set; }

        [CustomRequired]
        [Display(Name = "Superficie del Lote *")]
        public double SuperficieLote { get; set; }

        [CustomRequired]
        [Display(Name = "Datos del Libro *")]
        public string DatosLibro { get; set; }

        [CustomRequired]
        [Display(Name = "Folio del Documento *")]
        public string FolioDocumento { get; set; }

        [CustomRequired]
        [Display(Name = "Observaciones *")]
        public string Observaciones { get; set; }

        [CustomRequired]
        [Display(Name = "Procedencia*")]
        public int Procedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Motivos de la Procedencia o Improcedencia *")]
        public string MotivosProcedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha de la Dictaminacion*")]
        public DateTime FechaDicaminacion { get; set; }

        
        public string UsuarioDominio { get; set; }

    }
}
