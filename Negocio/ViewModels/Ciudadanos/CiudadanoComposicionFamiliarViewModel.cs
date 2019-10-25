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
    public class CiudadanoComposicionFamiliarViewModel
    {
        [CustomRequired]
        [Display(Name = "Condiciones de la organización civil de la familia *")]
        public int CIU_IDOrganizacionCivilFamilia { get; set; }

        [CustomRequired]
        [Display(Name = "Estructura Familiar *")]
        public int CIU_IDEstructuraFamiliar { get; set; }

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
        [Display(Name = "Ingreso Familiar *")]
        public double CIU_IngresoFamiliar { get; set; }

        public CiudadanoTrabajoViewModel Trabajo { get; set; }

        public CiudadanoComposicionFamiliarViewModel() {
            Trabajo = new CiudadanoTrabajoViewModel();
        }


        //Listas
        public ICustomSelectList<Entidades.Catalogos> OrganizacionCivilFamilia { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EstructuraFamiliar { get; set; }
        public ICustomSelectList<Entidades.Catalogos> EnfermedadCronica { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Discapacidad { get; set; }
        public ICustomSelectList<Entidades.Catalogos> GruposPrioritarios { get; set; }


    }
}
