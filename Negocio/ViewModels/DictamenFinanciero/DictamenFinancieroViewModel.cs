using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.DictamenFinanciero
{
    public class DictamenFinancieroViewModel
    {
        public string TipoCredito { get; set; }
        public int? IDDictamenFinanciero { get; set; }
        public int IDCredito{ get; set; }

        [CustomRequired]
        [Display(Name = "Con base en la solicitud y documentación, se determina que el crédito es *")]
        public int Procedencia { get; set; }

        [CustomRequired]
        [StringLength(10)]
        [Display(Name = "Motivos *")]
        public string MotivosProcedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Se considera un monto en el número de veces de la Unidad de Medida y Actualización (UMA) *")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El mínimo es 1")]
        public int NoMontoCredito { get; set; }

        [CustomRequired]
        [Display(Name = "Plazo de amortización en meses")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El mínimo es 1")]
        public int NoMesesAmortizacion { get; set; }

        public int IDUMA { get; set; }
        
        [CustomRequired]
        [Display(Name = "Pago mensual en UMA *")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El mínimo es 1")]
        public int NoPagoUMA { get; set; }

        [CustomRequired]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Dictaminación *")]
        public DateTime FechaDictaminacion { get; set; }

        public string UsuarioDominio { get; set; }


        //Listas

        public ICustomSelectList<Entidades.Catalogos> Dictaminacion { get; set; }
        
        }
}
