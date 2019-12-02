using Negocio.ViewModels.Ciudadanos;
using Negocio.ViewModels.Domicilio;
using Negocio.ViewModels.DomicilioCiudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.ComponentModel.DataAnnotations;

namespace Negocio.ViewModels.Ciudadanos
{
    public class CiudadanoInsertarViewModel
    {
        //Variables de vista
        #region  Variables de vista
        public bool CiudadanoExistente { get; set; }
        public bool CreditoInicial { get; set; }
        #endregion

        //Datos Personales
        #region Datos Personales
        public string ID_Encriptado { get; set; }

        [CustomRequired]
        [Display(Name = "CURP *")]
        [StringLength(18)]
        [RegularExpression("^[A-Z]{1}[AEIOU]{1}[A-Z]{2}[0-9]{2}(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[HM]{1}(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)[B-DF-HJ-NP-TV-Z]{3}[0-9A-Z]{1}[0-9]{1}$",ErrorMessage = "El CURP no es valido")]
        public string CIU_CURP { get; set; }

        [CustomRequired]
        [StringLength(70)]
        [Display(Name = "Nombre(s) *")]
        public string CIU_Nombre { get; set; }

        [CustomRequired]
        [StringLength(50)]
        [Display(Name = "Apellido Paterno *")]
        public string CIU_ApellidoPaterno { get; set; }

        [StringLength(50)]
        [Display(Name = "Apellido Materno")]
        public string CIU_ApellidoMaterno { get; set; }

        [CustomRequired]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "El Número de Identificación no es válido")]
        [Display(Name = "Número de Identificación *")]
        public string CIU_NumeroIdentificacion { get; set; }

        [CustomRequired]
        [Display(Name = "Género *")]
        public int CIU_IDGenero { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha de Nacimiento *")]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CIU_FechaNacimiento { get; set; }

        [CustomRequired]
        [Display(Name = "Entidad de Nacimiento *")]
        public int CIU_IDEstado { get; set; }

        [CustomRequired]
        [Range(1, 120)]
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
        [MinLength(8)]
        [StringLength(10)]
        [Display(Name = "Teléfono Particular *")]
        public string CIU_TelParticular { get; set; }

        [MinLength(8)]
        [StringLength(20)]
        [Display(Name = "Teléfono del Trabajo")]
        public string CIU_TelTrabajo { get; set; }

        [MinLength(8)]
        [StringLength(10)]
        [Display(Name = "Teléfono Celular")]
        public string CIU_TelCelular { get; set; }

        [MinLength(8)]
        [StringLength(10)]
        [Display(Name = "Teléfono para Recados")]
        public string CIU_TelRecados { get; set; }

        [CustomEmailAddress]
        [Display(Name = "Correo Electrónico")]
        [StringLength(50)]
        public string CIU_CorreoElectronico { get; set; }

        public int? CIU_IDDomicilioTrabajo { get; set; }

        #endregion

        //DomicilioCiudadano
        #region Domicilio Ciudadano

        public int? DOMC_IDDomicilio { get; set; }
        public int? DOMC_IDCiudadano { get; set; }

        [CustomRequired]
        [Display(Name = "Vialidad *")]
        public int DOMC_IDVialidad { get; set; }

        [CustomRequired]
        [StringLength(40)]
        [Display(Name = "Nombre de la Vialidad *")]
        public string DOMC_NombreVialidad { get; set; }


        [StringLength(10)]
        [Display(Name = "Número Exterior")]
        public string DOMC_NumeroExterior { get; set; }


        [StringLength(10)]
        [Display(Name = "Número Interior")]
        public string DOMC_NumeroInterior { get; set; }

        [StringLength(10)]
        [Display(Name = "Manzana")]
        public string DOMC_Manzana { get; set; }

        [StringLength(10)]
        [Display(Name = "Lote")]
        public string DOMC_Lote { get; set; }

        [CustomRequired]
        [StringLength(50)]
        [Display(Name = "Colonia *")]
        public string DOMC_Colonia { get; set; }

        [CustomRequired]
        [Display(Name = "Alcaldia *")]
        public int DOMC_IDAlcaldia { get; set; }

        [RegularExpression("^[0-9]{5}$", ErrorMessage = "El código postal no es válido")]
        [Display(Name = "Codigo Postal")]
        public string DOMC_CodigoPostal { get; set; }

        [CustomRequired]
        [Display(Name = "Estado *")]
        public int DOMC_IDEstado { get; set; }

        [CustomRequired]
        [RegularExpression("^(-?[1-8]?\\d(?:.\\d{1,18})?|90(?:.0{1,18})?)$", ErrorMessage = "La latitud no es válida")]
        [Display(Name = "Latitud *")]
        public string DOMC_Latitud { get; set; }

        [CustomRequired]
        [RegularExpression("^(-?(?:1[0-7]|[1-9])?\\d(?:.\\d{1,18})?|180(?:.0{1,18})?)$", ErrorMessage = "La longitud no es valida")]
        [Display(Name = "Longitud *")]
        public string DOMC_Longitud { get; set; }

        [Display(Name = "Monto Renta")]
        [Range(100.00, Double.MaxValue, ErrorMessage = "El monto mínimo es $100.00")]
        public double DOMC_MontoRenta { get; set; }

        [CustomRequired]
        [Display(Name = "Tipo de Vivienda *")]
        public int DOMC_IDTipoVivienda { get; set; }

        [Display(Name = "Otro ")]
        [StringLength(100)]
        public string DOMC_Otro { get; set; }

        #endregion

        //Creditos Otorgados
        [CustomRequired]
        [StringLength(50)]
        [Display(Name = "Propósito *")]
        public string CIU_Proposito { get; set; }

        [CustomRequired]
        [Display(Name = "Créditos Otorgados *")]
        public bool CIU_CreditosOtorgados { get; set; }

        //Composicion Familiar
        [CustomRequired]
        [Display(Name = "Condiciones de la organización civil de la familia *")]
        public int CIU_IDOrganizacionCivilFamilia { get; set; }

        [CustomRequired]
        [Display(Name = "Estructura Familiar *")]
        public int CIU_IDEstructuraFamiliar { get; set; }

        [CustomRequired]
        [Display(Name = "Enfermedad Crónica *")]
        public int CIU_IDEnfermedadCronica { get; set; }

        [StringLength(50)]
        [Display(Name = "Otra")]
        public string CIU_EnfermedadCronicaOtro { get; set; }

        [CustomRequired]
        [Display(Name = "Discapacidad *")]
        public int CIU_IDDiscapacidad { get; set; }

        
        [StringLength(50)]
        [Display(Name = "Otra")]
        public string CIU_DiscapacidadOtro { get; set; }

        [CustomRequired]
        [Display(Name = "Grupos Prioritarios *")]
        public int[] CIU_IDGruposPrioritarios { get; set; }

        [CustomRequired]
        [Display(Name = "Ingreso Familiar *")]
        public double CIU_IngresoFamiliar { get; set; }

        //Trabajo
        [CustomRequired]
        [Display(Name = "Ocupación *")]
        public int CIU_IDOcupacion { get; set; }

        [StringLength(50)]
        [Display(Name = "Dependencia, empresa o negocio")]
        public string CIU_NombreTrabajo { get; set; }

        //Capacidad de Pago
        [CustomRequired]
        [Display(Name = " De su ingreso familiar mensual,\n¿Cuánto podrá destinar para el pago del crédito? *")]
        [Range(100.00, Double.MaxValue, ErrorMessage = "El monto mínimo es $100.00")]
        public double CIU_CapacidadPago { get; set; }


        //Listas

        public ICustomSelectList<Entidades.Catalogos> Vialidad { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Alcaldia { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Estado { get; set; }
        public ICustomSelectList<Entidades.Catalogos> TipoVivienda { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Genero { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EstadoCivil { get; set; }
        public ICustomSelectList<Entidades.Catalogos> GradoEstudios { get; set; }
        public ICustomSelectList<Entidades.Catalogos> GrupoEtnico { get; set; }
        public ICustomSelectList<Entidades.Catalogos> OrganizacionCivilFamilia { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EstructuraFamiliar { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EnfermedadCronica { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Discapacidad { get; set; }
        public ICustomSelectList<Entidades.Catalogos> GruposPrioritarios { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Ocupacion { get; set; }

        public CiudadanoParejaViewModel Pareja { get; set; }
        public DomicilioFormViewModel Domicilio_Diferente { get; set; }
        public DomicilioFormViewModel Domicilio_Trabajo{ get; set; }
        public CiudadanoDeudorSolidarioViewModel DeudorSolidario { get; set; }


        public CiudadanoInsertarViewModel() {
        }
    }
}
