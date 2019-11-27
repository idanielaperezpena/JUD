using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.DictamenTecnico
{
    public class DictamenTecnicoViewModel
    {
        public string TipoCredito { get; set; }
        public int? IDDictamenTecnico { get; set; }
        public int IDCredito{ get; set; }

        [CustomRequired]
        [Display(Name = "Con base en el reporte de la visita técnica se determina que la solicitud es *")]
        public int IDProcedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Describa los motivos de procedencia o improcedencia *")]
        public string MotivosProcedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Monto Sugerido *")]
        public double MontoSugerido { get; set; }

        [CustomRequired]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de la Dictaminación *")]
        public DateTime FechaDictaminacion { get; set; }

        [CustomRequired]
        [Display(Name = "Asesor Técnico *")]
        public string NoAsesorTecnico { get; set; }

       
        public string UsuarioDominio { get; set; }

        #region Listas
        public ICustomSelectList<Entidades.Catalogos> Dictaminacion { get; set; }
        public ICustomSelectList<Entidades.Catalogos> AsesoriaTecnica { get; set; }
        #endregion
    }
}
