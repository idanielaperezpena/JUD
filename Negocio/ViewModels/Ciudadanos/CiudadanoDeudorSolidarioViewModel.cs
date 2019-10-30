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
    public class CiudadanoDeudorSolidarioViewModel
    {
        public int? DEU_IDDeudorSolidario { get; set; }
        public int? DEU_IDCiudadano { get; set; }
        public int? DEU_IDDomicilio { get; set; }
        public int? DEU_IDDomicilioTrabajo { get; set; }

        [CustomRequired]
        [Display(Name = "CURP *")]
        public string DEU_CURP { get; set; }

        [CustomRequired]
        [Display(Name = "Nombre *")]
        public string DEU_Nombre { get; set; }

        [CustomRequired]
        [Display(Name = "Apellido Paterno *")]
        public string DEU_ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string DEU_ApellidoMaterno { get; set; }

        [CustomRequired]
        [Display(Name = "Genero *")]
        public int DEU_IDGenero { get; set; }

        [CustomRequired]
        [Display(Name = "Estado Civil *")]
        public int DEU_IDEstadoCivil { get; set; }

        [CustomRequired]
        [Display(Name = "Tel. Particular *")]
        public string DEU_Telefono { get; set; }

        public Domicilio.DomicilioFormViewModel DomicilioActual { get; set; }

        [CustomRequired]
        [Display(Name = "Ocupación *")]
        public int DEU_IDProfesion { get; set; }

        [Display(Name = "Dependencia, empresa o negocio")]
        public string DEU_NombreTrabajo { get; set; }


        public Domicilio.DomicilioFormViewModel DomicilioTrabajo { get; set; }

        [CustomRequired]
        [Display(Name = "Ingreso familiar mensual *")]
        public double DEU_Ingreso { get; set; }

        [CustomRequired]
        [Display(Name = "De su ingreso familiar mensual,\n¿Cuánto podrá destinar para el pago del crédito ? *")]
        public double DEU_CapacidadPago { get; set; }

        [Display(Name = "Fecha de Solicitud")]
        public DateTime DEU_FechaSolicitud { get; set; }
        //Listas
        public ICustomSelectList<Entidades.Catalogos> Genero { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EstadoCivil { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Ocupacion { get; set; }

    }
}
