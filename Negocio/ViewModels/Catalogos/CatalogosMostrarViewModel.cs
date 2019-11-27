using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio.ViewModels.Catalogos
{
    public class CatalogosMostrarViewModel
    {

        [Display(Name = "Nombre Catálogo")]
        public string NombreCatalogo { get; set; }
        [Display(Name = "No. Catálogo")]
        public string NoCatalogo { get; set; }

        public string Tabla { get; set; }

        public bool TieneCGMA { get; set; }
        public bool TieneTipo { get; set; }

        public List<CatalogosMostrarListadoViewModel> Listado { get; set; }

        public CatalogosMostrarViewModel()
        {
            Listado = new List<CatalogosMostrarListadoViewModel>();
        }

    }

    public class CatalogosMostrarListadoViewModel 
    {

        public int? ID { get; set; }
        public string Clave { get; set; }
        [Display(Name = "Clave CGMA")]
        public int? ClaveCGMA { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool Activo { get; set; }
        [Display(Name = "Estatus")]
        public String Activo_Nombre { get; set; }

    }
}
