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

        public CatalogosIndexViewModel Index(CatalogosIndexViewModel viewModel = null)
        {
            if (viewModel == null)
                viewModel = new CatalogosIndexViewModel();

            try
            {
                var _listado = Listado_Tablas();

                String[] catalogo_colores = new string[3];
                catalogo_colores[0] = "bg-teal";
                catalogo_colores[1] = "bg-purple";
                catalogo_colores[2] = "bg-maroon";

                var num = 0;

                foreach (Catalogos _cat in _listado)
                {
                    var _temp = new CatalogosIndexListadoViewModel();

                    char[] spearator = { '_' };
                    String[] strlist = _cat.NombreCatalogo.Split(spearator);
                    _temp.NombreCatalogo = this.UoW.Encriptador.Encriptar(_cat.NombreCatalogo);
                    _temp.NombreCatalogo_Mostrar = strlist[3];
                    _temp.NoCatalogo = strlist[2];
                    _temp.Color_Caja = catalogo_colores[num];

                    if (num == 2)
                        num = 0;
                    else
                        num++;

                    viewModel.Listado.Add(_temp);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return viewModel;
        }


        public CatalogosMostrarViewModel Mostrar(string nombre)
        {
            viewModel = new CatalogosMostrarViewModel();

            try
            {
                var _listado = Listado_Tablas();

                String[] catalogo_colores = new string[3];
                catalogo_colores[0] = "bg-teal";
                catalogo_colores[1] = "bg-purple";
                catalogo_colores[2] = "bg-maroon";

                var num = 0;

                foreach (Catalogos _cat in _listado)
                {
                    var _temp = new CatalogosIndexListadoViewModel();

                    char[] spearator = { '_' };
                    String[] strlist = _cat.NombreCatalogo.Split(spearator);
                    _temp.NombreCatalogo = this.UoW.Encriptador.Encriptar(_cat.NombreCatalogo);
                    _temp.NombreCatalogo_Mostrar = strlist[3];
                    _temp.NoCatalogo = strlist[2];
                    _temp.Color_Caja = catalogo_colores[num];

                    if (num == 2)
                        num = 0;
                    else
                        num++;

                    viewModel.Listado.Add(_temp);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return viewModel;
        }


        public List<Catalogos> Listado_Tablas()
        {
            try
            {
                return UoW.Catalogos.ObtenerListado_NombreTablas(new Catalogos
                {
                    NombreCatalogo = "Prueba"
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
