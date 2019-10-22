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
    public class CiudadanoService : ServiceBase
    {
        public CiudadanoService(ModelStateDictionary modelState) : base(modelState) { }

        /* Vista */
        public CiudadanosIndexViewModel Index()
        {
            var viewModel = new CiudadanosIndexViewModel();

            try
            {
                var _listado = Listado();

                foreach (Ciudadano _cat in _listado)
                {
                    var _temp = new CiudadanosIndexListadoViewModel();

                    _temp.CIU_IDCiudadano = _cat.CIU_IDCiudadano;
                    _temp.CURP = _cat.CIU_CURP;
                    _temp.NombreCompleto = _cat.CIU_Nombre + " " + _cat.CIU_ApellidoPaterno + " " + _cat.CIU_ApellidoMaterno;

                    var _InfoCatalogo = this.UoW.Catalogos.ObtenerEntidad(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = _cat.CIU_IDGenero });

                    _temp.GeneroTexto = _InfoCatalogo.Descripcion;
                    _temp.DatosNacimiento = _cat.CIU_FechaNacimiento.Date.ToString();
                    _temp.Contacto = _cat.CIU_TelParticular;
                    _temp.DomicilioCompleto = _cat.CIU_IDDomicilio.ToString();

                    viewModel.Listado.Add(_temp);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Mostrar");
            }

            return viewModel;
        }

        /* Funciones */
        public List<Ciudadano> Listado()
        {
            try
            {
                return UoW.Ciudadano.ObtenerListado(new Ciudadano());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<Ciudadano>();
        }


        public Ciudadano ObtenerEntidad(int id_ciudadano)
        {
            try
            {
                return UoW.Ciudadano.ObtenerEntidad(new Ciudadano
                {
                    CIU_IDCiudadano = id_ciudadano
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return new Ciudadano();
        }

        public List<Ciudadano> Listado(string catalogo_nombre)
        {

            try
            {
                return UoW.Ciudadano.ObtenerListado(new Ciudadano());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return new List<Ciudadano>();
        }



    }
}
