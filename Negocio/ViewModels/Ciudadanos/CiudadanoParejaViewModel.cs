using Entidades;
using Negocio.ViewModels.DomicilioCiudadano;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Negocio.ViewModels.Ciudadanos
{
    public class CiudadanoParejaViewModel
    {
        public int? PAR_IDPareja { get; set; }

        public int? PAR_IDCiudadano { get; set; }

        [CustomRequired]
        [Display(Name = "Nombre *")]
        public string PAR_Nombre { get; set; }

        [CustomRequired]
        [Display(Name = "Apellido Paterno *")]
        public string PAR_ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno *")]
        public string PAR_ApellidoMaterno { get; set; }

        [CustomRequired]
        [Display(Name = "Género *")]
        public int PAR_IDGenero { get; set; }

        [Display(Name = "Régimen Patrimonial")]
        public int PAR_IDRegimen { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha de Nacimiento *")]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PAR_FechaNacimiento { get; set; }

        [CustomRequired]
        [Display(Name = "Entidad de Nacimiento *")]
        public int PAR_IDEstado { get; set; }

        //Listas
        public ICustomSelectList<Entidades.Catalogos> Genero { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Estado { get; set; }
        public ICustomSelectList<Entidades.Catalogos> RegimenPatrimonial { get; set; }
    }
}
