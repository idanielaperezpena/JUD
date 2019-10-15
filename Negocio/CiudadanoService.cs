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
    class CiudadanoService : ServiceBase
    {
        public CiudadanoService(ModelStateDictionary modelState) : base(modelState) { }

        /*
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
                return UoW.Ciudadano.ObtenerListado();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return new List<Ciudadano>();
        }*/



    }
}
