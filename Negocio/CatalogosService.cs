using Entidades;
using Entidades.Utilidades;
using Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;

namespace Negocio
{
    public class CatalogosService : ServiceBase
    {
        public CatalogosService(ModelStateDictionary modelState) : base(modelState) { }

        public List<Catalogos> Listado(string catalogo_nombre)
        {
            return UoW.Catalogos.ObtenerListado(new Catalogos
            {
                NombreCatalogo = catalogo_nombre
            });

            try
            {
                return UoW.Catalogos.ObtenerListado(new Catalogos
                {
                    NombreCatalogo = catalogo_nombre
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return new List<Catalogos>();
        }

    }
}
