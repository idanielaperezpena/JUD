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

        [CustomRequired]
        [Display(Name = "Apellido Materno *")]
        public string CIU_ApellidoMaterno { get; set; }

        [CustomRequired]
        [Display(Name = "Genero ")]
        public int CIU_IDGenero { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha de Nacimiento * ")]
        public DateTime CIU_FechaNacimiento { get; set; }

        [CustomRequired]
        [Display(Name = "Estado * ")]
        public int CIU_IDEstado { get; set; }

        public int? CIU_IDDomicilio { get; set; }

        [CustomRequired]
        [Display(Name = "Tiempo de Residencia * ")]
        public int CIU_TiempoResidencia { get; set; }

        [Display(Name = "Telefono Particular")]
        public string CIU_TelParticular { get; set; }

        [Display(Name = "Telefono para Recados")]
        public string CIU_TelRecados { get; set; }

        [Display(Name = "Telefono del Trabajo")]
        public string CIU_TelTrabajo { get; set; }

        [Display(Name = "Telefono Celular")]
        public string CIU_TelCelular { get; set; }

        [CustomRequired]
        [Display(Name = "Estado Civil *")]
        public int CIU_IDEstadoCivil { get; set; }

        [CustomRequired]
        [Display(Name = "Organización Civil de la Familia *")]
        public int CIU_IDOrganizacionCivilFamilia { get; set; }

        [CustomRequired]
        [Display(Name = "Grado de Estudios *")]
        public int CIU_IDGradoEstudios { get; set; }

        [CustomRequired]
        [Display(Name = "Grupo Etnico *")]
        public int CIU_IDgrupoEtnico { get; set; }

        [Display(Name = "Numero de Identificacion *")]
        public string CIU_NumeroIdentificacion { get; set; }

        [CustomRequired]
        [Display(Name = "Enfermedad Cronica *")]
        public int CIU_IDEnfermedadCronica { get; set; }

        [Display(Name = "Otra")]
        public string CIU_EnfermedadCronicaOtro { get; set; }

        [CustomRequired]
        [Display(Name = "Discapacidad *")]
        public int CIU_IDDiscapacidad { get; set; }

        [Display(Name = "Otra")]
        public string CIU_DiscapacidadOtro { get; set; }

        [CustomRequired]
        [Display(Name = "Grupos Prioritarios *")]
        public int CIU_IDGruposPrioritarios { get; set; }

        [CustomRequired]
        [Display(Name = "Proposito *")]
        public string CIU_Proposito { get; set; }

        [CustomRequired]
        [Display(Name = "Creditos Otorgados *")]
        public bool CIU_CreditosOtorgados { get; set; }

        [CustomRequired]
        [Display(Name = "Ingreso Familiar *")]
        public double CIU_IngresoFamiliar { get; set; }

        [CustomRequired]
        [Display(Name = "Estructura Familiar *")]
        public int CIU_IDEstructuraFamiliar { get; set; }

        [CustomRequired]
        [Display(Name = "Ocupacion *")]
        public int CIU_IDOcupacion { get; set; }

        [CustomRequired]
        [Display(Name = "Nombre del Trabajo *")]
        public string CIU_NombreTrabajo { get; set; }

        public int? CIU_IDDomicilioTrabajo { get; set; }

        [CustomRequired]
        [Display(Name = "Capacidad de Pago *")]
        public double CIU_CapacidadPago { get; set; }

        [Display(Name = "Correo Electronico")]
        public string CIU_CorreoElectronico { get; set; }

        //Listas

        public ICustomSelectList<Entidades.Catalogos> Genero { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Estado { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EstadoCivil { get; set; }
        public ICustomSelectList<Entidades.Catalogos> OrganizacionCivilFamilia { get; set; }
        public ICustomSelectList<Entidades.Catalogos> GradoEstudios { get; set; }
        public ICustomSelectList<Entidades.Catalogos> GrupoEtnico { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EnfermedadCronica { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Discapacidad { get; set; }
        public ICustomSelectList<Entidades.Catalogos> GruposPrioritarios { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EstructuraFamiliar { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Ocupacion { get; set; }
        // Calendarios

        public CalendarControl FechaNacimiento { get; set; }
    }
}
