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
    public class CiudadanoTrabajoViewModel
    {
        [CustomRequired]
        [Display(Name = "Ocupacion *")]
        public int CIU_IDOcupacion { get; set; }

        [Display(Name = "Dependencia, empresa o negocio")]
        public string CIU_NombreTrabajo { get; set; }

        // Listas
        public ICustomSelectList<Entidades.Catalogos> Ocupacion { get; set; }
    }
}
