
using Entidades;
using Negocio.ViewModels.Ciudadanos;
using Negocio.ViewModels.Domicilio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;

namespace Negocio
{
    public class DeudorSolidarioService : ServiceBase
    {
        public DeudorSolidarioService(ModelStateDictionary modelState) : base(modelState) { }

        public DeudorSolidarioService()
        {
        }

        //Vistas


        //ViewModel Vacio
        public CiudadanoDeudorSolidarioViewModel GetDeudorSolidario()
        {
            var _viewModel = new CiudadanoDeudorSolidarioViewModel();
            //Listas Datos Personales
            _viewModel.Genero = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
            _viewModel.EstadoCivil = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
            _viewModel.Ocupacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_15_Ocupacion", ID = 0 }).SelectListado();
            _viewModel.DomicilioActual = GetDomicilio();
            _viewModel.DomicilioTrabajo = GetDomicilio();
            return _viewModel;

        }

        public DomicilioFormViewModel GetDomicilio()
        {
            var _viewModel = new DomicilioFormViewModel();

            _viewModel.Vialidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_12_Vialidad", ID = 0 }).SelectListado();
            _viewModel.Alcaldia = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_Alcaldia", ID = 0 }).SelectListado();
            _viewModel.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.Boton = false;

            return _viewModel;
        }

        //ViewModel LLeno

        public CiudadanoDeudorSolidarioViewModel ObtenerDeudorSolidario(int? id_solicitante, CiudadanoDeudorSolidarioViewModel _viewModel)
        {
            try
            {
                var _entidad = UoW.DeudorSolidario.ObtenerEntidad(new DeudorSolidario
                {
                    DEU_IDCiudadano = id_solicitante
                });
                if (_entidad != null)
                {
                    //datos personales
                    _viewModel.DEU_IDDeudorSolidario = _entidad.DEU_IDDeudorSolidario;
                    _viewModel.DEU_IDCiudadano = _entidad.DEU_IDCiudadano;
                    _viewModel.DEU_CURP = _entidad.DEU_CURP;
                    _viewModel.DEU_Nombre = _entidad.DEU_Nombre;
                    _viewModel.DEU_ApellidoPaterno = _entidad.DEU_ApellidoPaterno;
                    _viewModel.DEU_ApellidoMaterno = _entidad.DEU_ApellidoMaterno;
                    _viewModel.DEU_IDGenero = _entidad.DEU_IDGenero;
                    _viewModel.DEU_IDDomicilio = _entidad.DEU_IDDomicilio;
                    _viewModel.DEU_Ingreso = _entidad.DEU_Ingreso;
                    _viewModel.DEU_CapacidadPago = _entidad.DEU_CapacidadPago;
                    _viewModel.DEU_Telefono = _entidad.DEU_Telefono;
                    _viewModel.DEU_IDEstadoCivil = _entidad.DEU_IDEstadoCivil;
                    _viewModel.DEU_IDProfesion = _entidad.DEU_IDProfesion;
                    _viewModel.DEU_NombreTrabajo = _entidad.DEU_NombreTrabajo;
                    _viewModel.DEU_IDDomicilioTrabajo = _entidad.DEU_IDDomicilioTrabajo;
                    _viewModel.DEU_FechaSolicitud = _entidad.DEU_FechaSolicitud;

                    //casa
                    ObtenerDomicilio(_entidad.DEU_IDDomicilio, _viewModel.DomicilioActual);
                    //trabajo
                    ObtenerDomicilio(_entidad.DEU_IDDomicilioTrabajo, _viewModel.DomicilioTrabajo);
                    return _viewModel;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return _viewModel;
        }

        public DomicilioFormViewModel ObtenerDomicilio(int? id, DomicilioFormViewModel _viewModel)
        {
            try
            {
                var _entidad = UoW.Domicilio.ObtenerEntidad(new Domicilio
                {
                    DOM_IDDomicilio = id

                });

                if (_entidad != null)
                {
                    _viewModel.DOM_IDDomicilio = _entidad.DOM_IDDomicilio;
                    _viewModel.DOM_IDVialidad = _entidad.DOM_IDVialidad;
                    _viewModel.DOM_NombreVialidad = _entidad.DOM_NombreVialidad;
                    _viewModel.DOM_NumeroExterior = _entidad.DOM_NumeroExterior;
                    _viewModel.DOM_NumeroInterior = _entidad.DOM_NumeroInterior;
                    _viewModel.DOM_Manzana = _entidad.DOM_Manzana;
                    _viewModel.DOM_Lote = _entidad.DOM_Lote;
                    _viewModel.DOM_Colonia = _entidad.DOM_Colonia;
                    _viewModel.DOM_IDAlcaldia = _entidad.DOM_IDAlcaldia;
                    _viewModel.DOM_CodigoPostal = _entidad.DOM_CodigoPostal;
                    _viewModel.DOM_IDEstado = _entidad.DOM_IDEstado;
                    _viewModel.DOM_Latitud = _entidad.DOM_Latitud;
                    _viewModel.DOM_Longitud = _entidad.DOM_Longitud;


                    return _viewModel;
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return _viewModel;
        }

        //DB
        public DeudorSolidario EditarDeudorSolidario(CiudadanoDeudorSolidarioViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (UoW.DeudorSolidario.TxScope = new TransactionScope())
                    {
                        var _entidad = UoW.DeudorSolidario.Alta(new DeudorSolidario
                        {
                            DEU_IDDeudorSolidario = viewModel.DEU_IDDeudorSolidario,
                            DEU_IDCiudadano = viewModel.DEU_IDCiudadano,
                            DEU_CURP = viewModel.DEU_CURP,
                            DEU_Nombre = viewModel.DEU_Nombre,
                            DEU_ApellidoPaterno = viewModel.DEU_ApellidoPaterno,
                            DEU_ApellidoMaterno = viewModel.DEU_ApellidoMaterno,
                            DEU_IDGenero = viewModel.DEU_IDGenero,
                            DEU_IDDomicilio = viewModel.DEU_IDDeudorSolidario,
                            DEU_Ingreso = viewModel.DEU_Ingreso,
                            DEU_CapacidadPago = viewModel.DEU_CapacidadPago,
                            DEU_Telefono = viewModel.DEU_Telefono,
                            DEU_IDEstadoCivil = viewModel.DEU_IDEstadoCivil,
                            DEU_IDProfesion = viewModel.DEU_IDProfesion,
                            DEU_NombreTrabajo = viewModel.DEU_NombreTrabajo,
                            DEU_IDDomicilioTrabajo = viewModel.DEU_IDDomicilioTrabajo,
                            DEU_FechaSolicitud = viewModel.DEU_FechaSolicitud,
                        });
                        UoW.DeudorSolidario.TxScope.Complete();
                        return _entidad;
                    }

                }
            }
            catch (Exception ex)
            {
                var LineNumber = new StackTrace(ex, true).GetFrame(0).GetFileLineNumber();
                ModelState.AddModelError(string.Empty, ex.Message + " DS " +LineNumber);
            }
            return new DeudorSolidario();
        }

    }
}
