using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.DictamenJuridico
{
    public class DictamenJuridicoViewModel
    {
        public string TipoCredito { get; set; }
        public int? IDDictamenJuridico { get; set; }
        public int IDCredito { get; set; }
        [CustomRequired]
        [Display(Name = "Propiedad (Inscritos en el R.P.P) *")]
        public int IDPropiedad { get; set; }

        [CustomRequired]
        [Display(Name = "Posesión *")]
        public int IDPosesion { get; set; }

        [CustomRequired]
        [Display(Name = "No de Documento de Propiedad o Posesión *")]
        [StringLength(50)]
        public string NoDocumentoPropiedad { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha del Documento *")]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaDocumento { get; set; }

        [CustomRequired]
        [Display(Name = "¿Se requiere anuencia? *")]
        public bool Anuencia { get; set; }

        [CustomRequired]
        [Display(Name = "Superficie del Lote *")]
        public double SuperficieLote { get; set; }

        [CustomRequired]
        [Display(Name = "Datos del Libro *")]
        [StringLength(50)]
        public string DatosLibro { get; set; }

        [CustomRequired]
        [StringLength(50)]
        [Display(Name = "Folio del Real *")]
        public string FolioDocumento { get; set; }

        [CustomRequired]
        [Display(Name = "Observaciones *")]
        [StringLength(50)]
        public string Observaciones { get; set; }

        [CustomRequired]
        [Display(Name = "Procedencia *")]
        public int Procedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Motivos de la Procedencia o Improcedencia *")]
        [StringLength(10)]
        public string MotivosProcedencia { get; set; }

        [CustomRequired]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de la Dictaminación *")]
        public DateTime FechaDictaminacion { get; set; }

        
        public string UsuarioDominio { get; set; }
        #region listas
        public ICustomSelectList<Entidades.Catalogos> TipoPropiedad { get; set; }
        public ICustomSelectList<Entidades.Catalogos> TipoPosesion { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Dictaminacion { get; set; }

        #endregion
    }
}
