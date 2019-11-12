using Entidades;
using Entidades.Utilidades;
using Negocio.ViewModels;
using Negocio.ViewModels.Ciudadanos;
using Negocio.ViewModels.CreditoInicial;
using Negocio.ViewModels.Domicilio;
using Negocio.ViewModels.DomicilioCiudadano;
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
    public class CreditoInicialService : ServiceBase
    {
        public CiudadanoService _serviceCiudadano ;

        public DeudorSolidarioService _serviceDSolidario ;

        public DomicilioService _serviceDomicilio ;

        public CreditoInicialService(ModelStateDictionary modelState) : base(modelState) {
            _serviceCiudadano = new CiudadanoService(modelState);
            _serviceDSolidario = new DeudorSolidarioService(modelState);
            _serviceDomicilio = new DomicilioService(modelState);
        }


        //Vistas

        public CreditoInicialIndexViewModel Index()
        {
            var viewModel = new CreditoInicialIndexViewModel();

            try
            {
                var _listado = Listado();

                foreach (CreditoInicial _cat in _listado)
                {
                    var _entidadCiudadano = UoW.Ciudadano.ObtenerEntidad(new Ciudadano
                    {
                        CIU_IDCiudadano = _cat.CI_IDCiudadano
                    });

                    var _temp = new CreditoInicialIndexListadoViewModel();

                    _temp.IDEncriptado = UoW.Encriptador.Encriptar(_cat.CI_IDCreditoInicial);
                    _temp.CI_FolioSolicitud = _cat.CI_FolioSolicitud;
                    _temp.CURPCiudadano = _entidadCiudadano.CIU_CURP;
                    _temp.NombreCiudadano = _entidadCiudadano.CIU_Nombre + " " + _entidadCiudadano.CIU_ApellidoPaterno + " " + _entidadCiudadano.CIU_ApellidoMaterno;
                    _temp.CI_FechaSolicitud = _cat.CI_FechaSolicitud.Date.ToShortDateString().ToString();
                    _temp.CI_IDSeccionElectoral = _cat.CI_IDSeccionElectoral;

                    _temp.ImgDS = new String[2];
                    _temp.ImgDS[0] = "darkgray";
                    _temp.ImgDS[1] = "fas fa-folder-minus";

                    _temp.ImgDT = new String[2];
                    _temp.ImgDT[0] = "orange";
                    _temp.ImgDT[1] = "fas fa-hourglass-half";

                    _temp.ImgDJ = new String[2];
                    _temp.ImgDJ[0] = "red";
                    _temp.ImgDJ[1] = "fas fa-times-circle";

                    _temp.ImgDF = new String[2];
                    _temp.ImgDF[0] = "forestgreen";
                    _temp.ImgDF[1] = "fas fa-check-square";

                    viewModel.Listado.Add(_temp);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Mostrar");
            }

            return viewModel;
        }

        public CreditoInicialInsertarViewModel Insertar()
        {
            var _viewModel = new CreditoInicialInsertarViewModel();
            _viewModel.ValidarCiudadano = new CiudadanoValidarViewModel();

            //Listas
            _viewModel.SeccionElectoral = UoW.SeccionElectoral.ObtenerListado(new SeccionElectoral { ID = 0 }).SelectListado();

            return _viewModel;
        }

        public CreditoInicialInsertarViewModel Insertar(string ID)
        {
            var _viewModel = ObtenerCI(ID);
            _viewModel.ValidarCiudadano = new CiudadanoValidarViewModel();

            //Listas
            _viewModel.SeccionElectoral = UoW.SeccionElectoral.ObtenerListado(new SeccionElectoral { ID = 0 }).SelectListado();

            return _viewModel;
        }

        //Funciones de View Model vacias
        public CiudadanoParejaViewModel GetParejaViewModel() {
            return _serviceCiudadano.GetParejaCiudadano();
        }

        public DomicilioFormViewModel GetDomicilioViewModel()
        {
            return _serviceDomicilio.GetDomicilio();
        }

        public CiudadanoDeudorSolidarioViewModel GetDeudorSolidario()
        {
            return _serviceDSolidario.GetDeudorSolidario();

        }

        //Funciones de View Model Llenas
        public CiudadanoInsertarViewModel CiudadanoInsertar(string IDEncriptado)
        {
            return _serviceCiudadano.GetCiudadanoInsertar(IDEncriptado);
        }

        public CreditoInicialInsertarViewModel ObtenerCI(string IDEncriptado)
        {
            var viewModel = new CreditoInicialInsertarViewModel();
            try
            {
                if (String.IsNullOrEmpty(IDEncriptado))
                    return viewModel;

                int? _ID_desencriptar = Int32.Parse(this.UoW.Encriptador.Desencriptar(IDEncriptado));

                //CIUDADANO
                var _entidad = UoW.CreditoInicial.ObtenerEntidad(new CreditoInicial
                {
                    CI_IDCreditoInicial = _ID_desencriptar
                });

                if (_entidad != null)
                {
                    //datos personales
                    viewModel.CI_IDCiudadano = _entidad.CI_IDCiudadano;
                    viewModel.CI_IDCiudadanoEncriptado = UoW.Encriptador.Encriptar(_entidad.CI_IDCiudadano);
                    viewModel.CI_IDCreditoInicial = _entidad.CI_IDCreditoInicial;
                    viewModel.CI_FolioSolicitud = _entidad.CI_FolioSolicitud;
                    viewModel.CI_FechaSolicitud = _entidad.CI_FechaSolicitud;
                    viewModel.CI_IDSeccionElectoral = _entidad.CI_IDSeccionElectoral;
                    viewModel.CI_Ingreso = _entidad.CI_Ingreso;
                    viewModel.CI_ComprobanteIngresos = _entidad.CI_ComprobanteIngresos;
                    viewModel.CI_CartaResponsiva = _entidad.CI_CartaResponsiva;

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }


            return viewModel;
        }



        //Funciones DB

        public void EditarCreditoInicial(CreditoInicialInsertarViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var CiudadanoInsertado = _serviceCiudadano.EditarCiudadano(viewModel.CiudadanoInsertar);
                    viewModel.CI_IDCiudadano = CiudadanoInsertado.CIU_IDCiudadano;
                    viewModel.CiudadanoInsertar.ID_Encriptado = CiudadanoInsertado.CIU_IDCiudadano.ToString();
                    _serviceCiudadano.EditarDomicilioCiudadano(viewModel.CiudadanoInsertar);


                    if (viewModel.CiudadanoInsertar.Pareja != null)
                    {
                        viewModel.CiudadanoInsertar.Pareja.PAR_IDCiudadano = CiudadanoInsertado.CIU_IDCiudadano;
                        _serviceCiudadano.EditarPareja(viewModel.CiudadanoInsertar.Pareja);
                    }

                    if (viewModel.CiudadanoInsertar.DeudorSolidario != null)
                    {
                        viewModel.CiudadanoInsertar.DeudorSolidario.DEU_IDCiudadano = CiudadanoInsertado.CIU_IDCiudadano;
                        viewModel.CiudadanoInsertar.DeudorSolidario.DEU_FechaSolicitud = viewModel.CI_FechaSolicitud;
                        _serviceDSolidario.EditarDeudorSolidario(viewModel.CiudadanoInsertar.DeudorSolidario);
                    }

                    var Domicilio = EditarDomicilio(viewModel.CiudadanoInsertar);
                    viewModel.CI_IDDomicilio = Domicilio.DOM_IDDomicilio;
                    viewModel.CI_Ingreso = viewModel.CiudadanoInsertar.CIU_IngresoFamiliar;

                    using (UoW.CreditoInicial.TxScope = new TransactionScope())
                    {

                        var _entidad = UoW.CreditoInicial.Alta(new CreditoInicial
                        {
                            CI_FolioSolicitud = viewModel.CI_FolioSolicitud,
                            CI_IDCiudadano = viewModel.CI_IDCiudadano,
                            CI_FechaCaptura = viewModel.CI_FechaCaptura,
                            CI_FechaSolicitud = viewModel.CI_FechaSolicitud,
                            CI_IDSeccionElectoral = viewModel.CI_IDSeccionElectoral,
                            CI_IDDomicilio = viewModel.CI_IDDomicilio,
                            CI_Ingreso = viewModel.CI_Ingreso,
                            CI_ComprobanteIngresos = viewModel.CI_ComprobanteIngresos,
                            CI_CartaResponsiva = viewModel.CI_CartaResponsiva
                        });

                        UoW.DomicilioCiudadano.TxScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                ModelState.AddModelError(string.Empty, ex.Message + " Linea : " + line);
            }
        }

        private Domicilio EditarDomicilio(CiudadanoInsertarViewModel viewModelMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (UoW.Domicilio.TxScope = new TransactionScope())
                    {
                        if (viewModelMaster.Domicilio_Diferente != null)
                        {
                            var viewModel = viewModelMaster.Domicilio_Diferente;
                            var _entidad = UoW.Domicilio.Alta(new Domicilio
                            {
                                DOM_IDDomicilio = viewModel.DOM_IDDomicilio,
                                DOM_IDVialidad = viewModel.DOM_IDVialidad,
                                DOM_NombreVialidad = viewModel.DOM_NombreVialidad,
                                DOM_NumeroExterior = viewModel.DOM_NumeroExterior,
                                DOM_NumeroInterior = viewModel.DOM_NumeroInterior,
                                DOM_Manzana = viewModel.DOM_Manzana,
                                DOM_Lote = viewModel.DOM_Lote,
                                DOM_Colonia = viewModel.DOM_Colonia,
                                DOM_IDAlcaldia = viewModel.DOM_IDAlcaldia,
                                DOM_CodigoPostal = viewModel.DOM_CodigoPostal,
                                DOM_IDEstado = viewModel.DOM_IDEstado,
                                DOM_Latitud = viewModel.DOM_Latitud,
                                DOM_Longitud = viewModel.DOM_Longitud,

                            });

                            UoW.Domicilio.TxScope.Complete();
                            return _entidad;
                        }
                        else
                        {
                            var viewModel = viewModelMaster;
                            var _entidad = UoW.Domicilio.Alta(new Domicilio
                            {
                                DOM_IDVialidad = viewModel.DOMC_IDVialidad,
                                DOM_NombreVialidad = viewModel.DOMC_NombreVialidad,
                                DOM_NumeroExterior = viewModel.DOMC_NumeroExterior,
                                DOM_NumeroInterior = viewModel.DOMC_NumeroInterior,
                                DOM_Manzana = viewModel.DOMC_Manzana,
                                DOM_Lote = viewModel.DOMC_Lote,
                                DOM_Colonia = viewModel.DOMC_Colonia,
                                DOM_IDAlcaldia = viewModel.DOMC_IDAlcaldia,
                                DOM_CodigoPostal = viewModel.DOMC_CodigoPostal,
                                DOM_IDEstado = viewModel.DOMC_IDEstado,
                                DOM_Latitud = viewModel.DOMC_Latitud,
                                DOM_Longitud = viewModel.DOMC_Longitud,

                            });

                            UoW.Domicilio.TxScope.Complete();
                            return _entidad;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return new Domicilio();
        }

        //Listados

        public List<CreditoInicial> Listado()
        {
            try
            {
                return UoW.CreditoInicial.ObtenerListado(new CreditoInicial());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<CreditoInicial>();
        }
    }
}
