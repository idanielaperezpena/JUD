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
        [Display(Name = "Numero de Identificacion *")]
        public string CIU_NumeroIdentificacion { get; set; }

        [CustomRequired]
        [Display(Name = "Genero *")]
        public int CIU_IDGenero { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha de Nacimiento *")]
        public DateTime CIU_FechaNacimiento { get; set; }

        [CustomRequired]
        [Display(Name = "Entidad de Nacimiento *")]
        public int CIU_IDEstado { get; set; }

        public int? CIU_IDDomicilio { get; set; }

        [CustomRequired]
        [Display(Name = "Tiempo de Residencia en la CDMX *")]
        public int CIU_TiempoResidencia { get; set; }

        [CustomRequired]
        [Display(Name = "Grado Máximo de Estudios *")]
        public int CIU_IDGradoEstudios { get; set; }

        [CustomRequired]
        [Display(Name = "Grupo Étnico *")]
        public int CIU_IDgrupoEtnico { get; set; }

        [CustomRequired]
        [Display(Name = "Estado Civil *")]
        public int CIU_IDEstadoCivil { get; set; }

        [CustomRequired]
        [Display(Name = "Telefono Particular *")]
        public string CIU_TelParticular { get; set; }

        [Display(Name = "Telefono del Trabajo")]
        public string CIU_TelTrabajo { get; set; }

        [Display(Name = "Telefono Celular")]
        public string CIU_TelCelular { get; set; }

        [Display(Name = "Telefono para Recados")]
        public string CIU_TelRecados { get; set; }

        [CustomEmailAddress]
        [Display(Name = "Correo Electronico")]
        public string CIU_CorreoElectronico { get; set; }

        public int? CIU_IDDomicilioTrabajo { get; set; }

        public bool Boton { get; set; } 

        //Listas

        public ICustomSelectList<Entidades.Catalogos> Genero { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Estado { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EstadoCivil { get; set; }  
        public ICustomSelectList<Entidades.Catalogos> GradoEstudios { get; set; }
        public ICustomSelectList<Entidades.Catalogos> GrupoEtnico { get; set; }


        public CiudadanoDatosPersonalesViewModel() {
            Boton = true;
        }
    }
}
