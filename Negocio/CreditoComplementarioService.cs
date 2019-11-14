using Entidades;
using Negocio.ViewModels.CreditoComplementario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Negocio
{
    public class CreditoComplementarioService : ServiceBase
    {
        public CreditoComplementarioService(ModelStateDictionary modelState) : base(modelState)
        {
        }

        //Vistas 

        public CreditoCompementarioIndexViewModel Index()
        {
            var viewModel = new CreditoCompementarioIndexViewModel();

            try
            {
                var _listado = Listado();

                foreach (CreditoComplementario _cat in _listado)
                {
                    //viewModel.Listado.Add(_temp);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Mostrar");
            }

            return viewModel;
        }


        //DB


        public List<CreditoComplementario> Listado()
        {
            try
            {
                return UoW.CreditoComplementario.ObtenerListado(new CreditoComplementario());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<CreditoComplementario>();
        }
    }
}
