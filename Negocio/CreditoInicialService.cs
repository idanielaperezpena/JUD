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
        public CiudadanoService _serviceCiudadano;

        public DeudorSolidarioService _serviceDSolidario;

        public DomicilioService _serviceDomicilio;

        public CreditoInicialService(ModelStateDictionary modelState) : base(modelState) {
            _serviceCiudadano = new CiudadanoService(modelState);
            _serviceDSolidario = new DeudorSolidarioService(modelState);
            _serviceDomicilio = new DomicilioService(modelState);
        }

        public CreditoInicialService(ModelStateDictionary modelState,int OPC) : base(modelState)
        {

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
                    _temp.CI_ID = _cat.CI_IDCreditoInicial;
                    _temp.CI_FolioSolicitud = _cat.CI_FolioSolicitud;
                    _temp.CURPCiudadano = _entidadCiudadano.CIU_CURP;
                    _temp.NombreCiudadano = _entidadCiudadano.CIU_Nombre + " " + _entidadCiudadano.CIU_ApellidoPaterno + " " + _entidadCiudadano.CIU_ApellidoMaterno;
                    _temp.CI_FechaSolicitud = _cat.CI_FechaSolicitud.Date.ToShortDateString().ToString();

                    var se = UoW.SeccionElectoral.ObtenerEntidad(new SeccionElectoral { ID = _cat.CI_IDSeccionElectoral });
                    _temp.CI_IDSeccionElectoral = se.ClaveSE;

                    var estatus = EstatusCI(_cat.CI_IDCreditoInicial);

                    var cadena = estatus.Resultado.Split('-');

                    _temp.ImgDS = ImagenIndex(cadena[0]);
                    _temp.ImgDT = ImagenIndex(cadena[1]);
                    _temp.ImgDJ = ImagenIndex(cadena[2]);
                    _temp.ImgDF = ImagenIndex(cadena[3]);

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
            var uts = UoW.UnidadTerritorial.ObtenerListado(new UnidadTerritorial ());
            List<UnidadTerritorial> uts_filtradas = new List<UnidadTerritorial>();

            foreach (var _ut in uts)
            {
                if (_ut.ClaveMesa == 1)
                {
                    uts_filtradas.Add(_ut);
                }
            }
            _viewModel.UnidadTerritorial = uts_filtradas.SelectListado();

            var sec = UoW.SeccionElectoral.ObtenerListado(new SeccionElectoral());
            List<SeccionElectoral> sec_filtradas = new List<SeccionElectoral>();

            foreach (var _se in sec)
            {
                if (_se.ClaveUT == uts_filtradas.First().Clave)
                {
                    sec_filtradas.Add(_se);
                }
            }
            _viewModel.SeccionElectoral = sec_filtradas.SelectListado();

            return _viewModel;
        }

        public CreditoInicialInsertarViewModel Insertar(string ID)
        {
            var _viewModel = ObtenerCI(ID);
            _viewModel.ValidarCiudadano = new CiudadanoValidarViewModel();

            var se = UoW.SeccionElectoral.ObtenerEntidad(new SeccionElectoral { ID = _viewModel.CI_IDSeccionElectoral});

            var uts = UoW.UnidadTerritorial.ObtenerListado(new UnidadTerritorial());
            List<UnidadTerritorial> uts_filtradas = new List<UnidadTerritorial>();

            UnidadTerritorial Ut_Seleccionada = new UnidadTerritorial();

            //obtener la ut seleccionada
            foreach (var _ut in uts)
            {
                if (_ut.Clave == se.ClaveUT)
                {
                    Ut_Seleccionada = _ut;
                    break;
                }
            }

            foreach (var _ut in uts)
            {
                if (_ut.ClaveMesa == Ut_Seleccionada.ClaveMesa)
                {
                    uts_filtradas.Add(_ut);
                }
            }

            _viewModel.UnidadTerritorial = uts_filtradas.SelectListado();
            _viewModel.ID_UnidadTerritorial = (int) Ut_Seleccionada.ID;

            //obtener secciones de acuero a la ut
            var sec = UoW.SeccionElectoral.ObtenerListado(new SeccionElectoral());
            List<SeccionElectoral> sec_filtradas = new List<SeccionElectoral>();

            foreach (var _se in sec)
            {
                if (_se.ClaveUT == Ut_Seleccionada.Clave)
                {
                    sec_filtradas.Add(_se);
                }
            }
            _viewModel.SeccionElectoral = sec_filtradas.SelectListado();

            return _viewModel;
        }

        public String[] ImagenIndex(string cadena)
        {
            String[] Imagen = new String[2];
            switch (cadena)
            {
                case "0":
                    Imagen[0] = "darkgray";
                    Imagen[1] = "fas fa-folder-minus";
                    break;
                case "1":
                    Imagen[0] = "orange";
                    Imagen[1] = "fas fa-hourglass-half";
                    break;
                case "2":
                    Imagen[0] = "forestgreen";
                    Imagen[1] = "fas fa-check-square";
                    break;
                case "4":
                    Imagen[0] = "red";
                    Imagen[1] = "fas fa-times-circle";
                    break;
                default:
                    Imagen[0] = "red";
                    Imagen[1] = "fas fa-times-circle";
                    break;
            }

            return Imagen;
        }


        //Funciones de View Model vacias
        public CiudadanoParejaViewModel GetParejaViewModel() {
            return _serviceCiudadano.GetParejaCiudadano();
        }

        public DomicilioFormViewModel GetDomicilioViewModel()
        {
            return _serviceDomicilio.GetDomicilio();
        }

        public DomicilioFormViewModel GetDomicilioViewModel(int? ID)
        {
            var vm = _serviceDomicilio.GetDomicilio();
            vm = _serviceDomicilio.ObtenerDomicilio(ID, vm);
            return vm;
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
                    viewModel.CI_IDDomicilio = _entidad.CI_IDDomicilio;
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
                    if (CiudadanoInsertado.CIU_IDCiudadano != null)
                    {
                        if (ValidarCI((int)CiudadanoInsertado.CIU_IDCiudadano))
                        {
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
                                    CI_IDCreditoInicial = viewModel.CI_IDCreditoInicial,
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
                    
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message );
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

        public Principal EstatusCI(int? ID)
        {
            try
            {
                return UoW.Principal.ObetenerEstatusCI(new CreditoInicial { CI_IDCreditoInicial = ID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new Principal();
        }

        public bool ValidarCI(int id)
        {
            try
            {
                bool validacion = true;
                var listadoCI = Listado_Ciudadano(id);
                foreach (var _ci in listadoCI)
                {
                    var estatus = EstatusCI(_ci.CI_IDCreditoInicial);
                    var cadena = estatus.Resultado.Split('-');
                    if (cadena[3] == "2" || !cadena.Contains("4"))
                    {
                        validacion = false;
                    }
                }
                return validacion;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : EditCreditoSustentabilidad");
            }

            return false;
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


        public List<CreditoInicial> Listado_Ciudadano(int? ID)
        {
            try
            {
                return UoW.CreditoInicial.ObtenerListadoCiudadano(new CreditoInicial { CI_IDCiudadano = ID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<CreditoInicial>();
        }

        public ICustomSelectList<SeccionElectoral> ListadoSelectSeccionElectoral(int IDUT)
        {

            var ut = UoW.UnidadTerritorial.ObtenerEntidad(new UnidadTerritorial {  ID = IDUT });

            var sec = UoW.SeccionElectoral.ObtenerListado(new SeccionElectoral { ID = 0 });
            List<SeccionElectoral> sec_filtradas = new List<SeccionElectoral>();

            foreach (var _se in sec)
            {
                if (_se.ClaveUT == ut.Clave)
                {
                    sec_filtradas.Add(_se);
                }
            }

            return sec_filtradas.SelectListado();
        }
    }
}
