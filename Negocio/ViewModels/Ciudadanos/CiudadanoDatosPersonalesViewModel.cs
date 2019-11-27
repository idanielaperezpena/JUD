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
    public class CiudadanoDatosPersonalesViewModel
    {
        public string ID_Encriptado { get; set; }

        public int? ID { get; set; }

        [CustomRequired]
        [Display(Name = "CURP *")]
        public string CIU_CURP { get; set; }

        [CustomRequired]
        [Display(Name = "Nombre(s) *")]
        public string CIU_Nombre { get; set; }

        [CustomRequired]
        [Display(Name = "Apellido Paterno *")]
        public string CIU_ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string CIU_ApellidoMaterno { get; set; }

        [CustomRequired]
        [Display(Name = "Numero de Identificación *")]
        public string CIU_NumeroIdentificacion { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha de Nacimiento *")]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CIU_FechaNacimiento { get; set; }

    }
}
