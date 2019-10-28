using Entidades;
using Entidades.Utilidades;
using Negocio.ViewModels;
using Negocio.ViewModels.Ciudadanos;
using Negocio.ViewModels.CreditoInicial;
using Negocio.ViewModels.Domicilio;
using Negocio.ViewModels.DomicilioCiudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;

namespace Negocio
{
    public class CreditoInicialService : ServiceBase
    {
        public CreditoInicialService(ModelStateDictionary modelState) : base(modelState) { }

        //Vistas
        public CreditoInicialNuevoViewModel Nuevo()
        {
            var _viewModel = new CreditoInicialNuevoViewModel();

            _viewModel.DatosPersonales = GetDatosPesonales();
            _viewModel.DatosPersonales.Boton = false;
            _viewModel.DomicilioCiudadano = GetDomicilioCiudadano();
            _viewModel.DomicilioCiudadano.Boton = false;
            _viewModel.DomicilioCiudadano.CreditoInicial = true;

            _viewModel.ComposicionFamiliar = GetComposicionFamiliar();

            return _viewModel;
        }


        public CiudadanoParejaViewModel GetParejaViewModel() {
            return GetParejaCiudadano();
        }

        public DomicilioFormViewModel GetDomicilioViewModel()
        {
            return GetDomicilio();
        }


        //Funciones

        private CiudadanoDatosPersonalesViewModel GetDatosPesonales() {

            var _viewModel = new CiudadanoDatosPersonalesViewModel();

            _viewModel.Genero = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
            _viewModel.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.EstadoCivil = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
            _viewModel.GradoEstudios = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_09_Escolaridad", ID = 0 }).SelectListado();
            _viewModel.GrupoEtnico = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_10_GrupoEtnico", ID = 0 }).SelectListado();

            return _viewModel;
        }

        private DomicilioFormViewModel GetDomicilio()
        {

            var _viewModel = new DomicilioFormViewModel();

            _viewModel.Vialidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
            _viewModel.Alcaldia = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
            _viewModel.TipoVivienda = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_09_Escolaridad", ID = 0 }).SelectListado();

            _viewModel.Boton = false;

            return _viewModel;
        }

        private DomicilioCiudadanoFormViewModel GetDomicilioCiudadano()
        {

            var _viewModel = new DomicilioCiudadanoFormViewModel();

            //Listas Datos Personales
            _viewModel.Vialidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
            _viewModel.Alcaldia = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
            _viewModel.TipoVivienda = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_09_Escolaridad", ID = 0 }).SelectListado();

            return _viewModel;
        }

        private CiudadanoParejaViewModel GetParejaCiudadano()
        {

            var _viewModel = new CiudadanoParejaViewModel();

            //Listas Datos Personales
            _viewModel.Genero = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
            _viewModel.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.RegimenPatrimonial = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
            return _viewModel;
        }

        private CiudadanoComposicionFamiliarViewModel GetComposicionFamiliar()
        {

            var _viewModel = new CiudadanoComposicionFamiliarViewModel();

            //Listas Datos Personales
            _viewModel.OrganizacionCivilFamilia = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
            _viewModel.EstructuraFamiliar = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.EnfermedadCronica = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
            _viewModel.Discapacidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
            _viewModel.GruposPrioritarios = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();

            _viewModel.Trabajo.Ocupacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();


            return _viewModel;
        }


    }
}
