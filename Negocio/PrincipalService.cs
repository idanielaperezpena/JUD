using Negocio.ViewModels.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Negocio
{
    public class PrincipalService : ServiceBase
    {
        public PrincipalService(ModelStateDictionary modelState) : base(modelState) { }

        public PrincipalIndexViewModel ObtenerPrincipal()
        {
            var _viewModel = new PrincipalIndexViewModel();

            try
            {
                var _entidad = UoW.Principal.ObtenerDatosPrincipal();

                if (_entidad != null)
                {
                    _viewModel.TotalCreditos = _entidad.TotalCreditos;
                    _viewModel.TotalCreditosDictaminados = _entidad.TotalCreditosDictaminados;
                    _viewModel.TotalCreditosNuevos = _entidad.TotalCreditos - _entidad.TotalCreditosTerminados - _entidad.TotalCreditosDictaminados;
                    _viewModel.TotalCreditosTerminados = _entidad.TotalCreditosTerminados;


                    return _viewModel;
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return _viewModel;
        }

        //Funciones DB


    }
}
