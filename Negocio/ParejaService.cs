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
    class ParejaService : ServiceBase
    {
        public ParejaService(ModelStateDictionary modelState) : base(modelState) { }

        /*
        public Pareja ObtenerEntidad(int id_solicitante)
        {
            try
            {
                return UoW.Pareja.ObtenerEntidad(new Pareja
                {
                    PAR_IDPareja = id_solicitante
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return new Pareja();
        }*/
    }
}
