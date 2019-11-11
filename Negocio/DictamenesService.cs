using Entidades;
using Negocio.ViewModels.DictamenFinanciero;
using Negocio.ViewModels.DictamenJuridico;
using Negocio.ViewModels.DictamenSocial;
using Negocio.ViewModels.DictamenTecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Negocio
{
    public class DictamenesService : ServiceBase
    {
        public DictamenesService(ModelStateDictionary modelState) : base(modelState){}

        #region ViewModel
        public DictamenJuridicoViewModel InsertarDictamenJuridico()
        {
            var _viewModel = new DictamenJuridicoViewModel();
            //Listas
            _viewModel.TipoPropiedad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_TipoPropiedad", ID = 0 }).SelectListado();
            _viewModel.TipoPosesion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_Posesion", ID = 0 }).SelectListado();
            _viewModel.Dictaminacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_54_Dictaminacion", ID = 0 }).SelectListado();
            return _viewModel;
        }

        public DictamenSocialViewModel InsertarDictamenSocial()
        {
            var _viewModel = new DictamenSocialViewModel();
            //Listas
            _viewModel.TipoPredio = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_26_TipoPredio", ID = 0 }).SelectListado();
            _viewModel.CaracteristicasPredio = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_27_CaracteristicaPredio", ID = 0 }).SelectListado();
            _viewModel.ServicioAgua = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_21_ServicioAgua", ID = 0 }).SelectListado();
            _viewModel.ServicioDrenaje = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_22_Drenaje", ID = 0 }).SelectListado();
            _viewModel.ServicioElectrico = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_23_EnergiaElectrica", ID = 0 }).SelectListado();
            _viewModel.Hacinamiento = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_24_Hacinamiento", ID = 0 }).SelectListado();
            _viewModel.Insalubridad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_25_Insalubridad", ID = 0 }).SelectListado();
            _viewModel.Vulnerabilidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_63_GruposVulnerables", ID = 0 }).SelectListado();
            _viewModel.Dictaminacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_54_Dictaminacion", ID = 0 }).SelectListado();

            return _viewModel;
         
    }

        public DictamenTecnicoViewModel InsertarDictamenTecnico()
        {
            var _viewModel = new DictamenTecnicoViewModel();
            //Listas
            _viewModel.AsesoriaTecnica = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_46_AsesoriaTecnica", ID = 0 }).SelectListado();
            _viewModel.Dictaminacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_54_Dictaminacion", ID = 0 }).SelectListado();

            return _viewModel;
        }

        public DictamenFinancieroViewModel InsertarDictamenFinanciero()
        {
            var _viewModel = new DictamenFinancieroViewModel();
            //Listas
            _viewModel.Dictaminacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_54_Dictaminacion", ID = 0 }).SelectListado();

            return _viewModel;
        }
        #endregion
    }
}
