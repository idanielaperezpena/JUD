using Entidades;
using Entidades.Utilidades;
using Negocio.ViewModels;
using Negocio.ViewModels.Catalogos;
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
        /* Vistas */
        public CatalogosService(ModelStateDictionary modelState) : base(modelState) { }

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
            var viewModel = new CatalogosMostrarViewModel();

            try
            {
                var _nombre_desencriptar = this.UoW.Encriptador.Desencriptar(nombre);
                var _listado = Listado(_nombre_desencriptar);

                if (TieneCGMA(_listado)) 
                    viewModel.TieneCGMA = true;
                else
                    viewModel.TieneCGMA = false;

                if (TieneTipo(_listado))
                    viewModel.TieneTipo = true;
                else
                    viewModel.TieneTipo = false;

                char[] spearator = { '_' };
                String[] strlist = _nombre_desencriptar.Split(spearator);
                viewModel.NombreCatalogo = strlist[3];
                viewModel.NoCatalogo = strlist[2];

                foreach (Catalogos _cat in _listado)
                {
                    var _temp = new CatalogosMostrarListadoViewModel();

                    _temp.ID = _cat.ID;
                    _temp.Clave = _cat.Clave;
                    _temp.ClaveCGMA = _cat.ClaveCGMA;
                    _temp.Tipo = _cat.Tipo;
                    _temp.Descripcion = _cat.Descripcion;

                    _temp.Activo = _cat.Activo;
                    if (_cat.Activo) 
                        _temp.Activo_Nombre = "Activo";
                    else
                        _temp.Activo_Nombre = "Inactivo";
                    viewModel.Listado.Add(_temp);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Mostrar");
            }

            return viewModel;
        }

        public CatalogosMostrarModalViewModel GetModal(string nombre ,int ID )
        {
            var _ViewModel = new CatalogosMostrarModalViewModel();
            
            try {
                if(ID != 0)
                {

                    _ViewModel.Label = this.UoW.Encriptador.Desencriptar(nombre) + "  Agregar " + ID;
                    
                    var _InfoCatalogo = this.UoW.Catalogos.ObtenerEntidad(new Catalogos { NombreCatalogo = this.UoW.Encriptador.Desencriptar(nombre), ID = ID });

                    _ViewModel.Estatus = UoW.Catalogos.ObtenerEstatus().SelectListado();
                    _ViewModel.Label = "Agregar" + ID;

                    if (_InfoCatalogo != null)
                    {
                        _ViewModel.Label = "Editar";
                        _ViewModel.ID = _InfoCatalogo.ID;
                        _ViewModel.Clave = _InfoCatalogo.Clave;
                        _ViewModel.ClaveCGMA = _InfoCatalogo.ClaveCGMA;
                        _ViewModel.Descripcion = _InfoCatalogo.Descripcion;
                        _ViewModel.Activo = _InfoCatalogo.Activo; 
                    }

                }
                else
                {
                    _ViewModel.Label = "Agregar";
                    _ViewModel.Estatus = UoW.Catalogos.ObtenerEstatus().SelectListado();
                }

            }
            catch (Exception ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
            }


            return _ViewModel;
        }

        public void Editar(CatalogosMostrarModalViewModel ViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.Catalogos.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.Catalogos.Alta(new Catalogos
                        {
                            ID = ViewModel.ID,
                            Clave = ViewModel.Clave,
                            ClaveCGMA = ViewModel.ClaveCGMA,
                            Descripcion = ViewModel.Descripcion,
                            Activo = ViewModel.Activo
                        });

                        UoW.Catalogos.TxScope.Complete();
                    }
                }

            }catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }



        /* Funciones  */
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

        public List<Catalogos> Listado(string catalogo_nombre)
        {
            try
            {
                return UoW.Catalogos.ObtenerListado(new Catalogos
                {
                    NombreCatalogo = catalogo_nombre,
                    ID = 0
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<Catalogos>();
        }

        public bool TieneCGMA(List<Catalogos> Catalogos)
        {
            bool cgma = false;
            foreach (Catalogos Cat in Catalogos){
                if (Cat.ClaveCGMA != 0)
                {
                    cgma = true;
                }
            }

            return cgma;
        }

        public bool TieneTipo(List<Catalogos> Catalogos)
        {
            bool tipo = false;
            foreach (Catalogos Cat in Catalogos)
            {
                if (!String.IsNullOrEmpty(Cat.Tipo) )
                {
                    tipo = true;
                }
            }

            return tipo;
        }



    }
}
