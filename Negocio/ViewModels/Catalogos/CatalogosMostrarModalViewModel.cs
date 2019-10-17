using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio.ViewModels.Catalogos
{
    public class CatalogosMostrarModalViewModel
    {

        public string Label { get; set; }

        [Display(Name = "ID *")]
        public int? ID { get; set; }

        [CustomRequired]
        [Display(Name = "Clave *")]
        public int Clave { get; set; }

        [CustomRequired]
        [Display(Name = "Clave CGMA *")]
        public int ClaveCGMA { get; set; }

        [CustomRequired]
        [Display(Name = "Descripción *")]
        public string Descripcion { get; set; }

        [CustomRequired]
        [Display(Name = "Estatus *")]
        public bool? Activo { get; set; }

        public ICustomSelectList<Entidades.Catalogos> Estatus { get; set; }

    }
}
