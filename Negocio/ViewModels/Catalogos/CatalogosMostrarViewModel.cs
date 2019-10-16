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

        [Display(Name = "Nombre Catalogo")]
        public string NombreCatalogo { get; set; }
        [Display(Name = "No. Catalogo")]
        public string NoCatalogo { get; set; }

        public bool TieneCGMA { get; set; }

        public List<CatalogosMostrarListadoViewModel> Listado { get; set; }

        public CatalogosMostrarViewModel()
        {
            Listado = new List<CatalogosMostrarListadoViewModel>();
        }

    }

    public class CatalogosMostrarListadoViewModel : Entidades.Catalogos
    {

        public int? ID { get; set; }
        public int Clave { get; set; }
        [Display(Name = "Clave CGMA")]
        public int? ClaveCGMA { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        [Display(Name = "Estatus")]
        public String Activo_Nombre { get; set; }

    }
}
