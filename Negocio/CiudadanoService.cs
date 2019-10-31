using Entidades;
using Entidades.Utilidades;
using Negocio.ViewModels;
using Negocio.ViewModels.Ciudadanos;
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

                    _temp.IDEncriptado = UoW.Encriptador.Encriptar(_cat.CIU_IDCiudadano);
                    _temp.CURP = _cat.CIU_CURP;
                    _temp.NombreCompleto = _cat.CIU_Nombre + " " + _cat.CIU_ApellidoPaterno + " " + _cat.CIU_ApellidoMaterno;

                    var _InfoCatalogo = this.UoW.Catalogos.ObtenerEntidad(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = _cat.CIU_IDGenero });

                    _temp.GeneroTexto = _InfoCatalogo.Descripcion;
                    _temp.DatosNacimiento = _cat.CIU_FechaNacimiento.Date.ToShortDateString().ToString();
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

        public CiudadanoInsertarViewModel Insertar(string IDEncriptado=null)
        {
            var viewModel = new CiudadanoInsertarViewModel();
            //Catalogos Ciudadano
            ObtenerCatalogos(viewModel);
            //DomicilioDeltrabajo
            viewModel.Domicilio_Trabajo = GetDomicilio();
            //deudor solidario
            viewModel.DeudorSolidario = GetDeudorSolidario();
            ////Domicilio otro
            //viewModel.Domicilio_Diferente = GetDomicilio();
            //Pareja
            viewModel.Pareja = GetParejaCiudadano();
            var _ID_desencriptar = Int32.Parse(this.UoW.Encriptador.Desencriptar(IDEncriptado));
            try
            {
                //CIUDADANO
                var _entidad = UoW.Ciudadano.ObtenerEntidad(new Ciudadano
                {
                    CIU_IDCiudadano = _ID_desencriptar
                });

                if (_entidad != null)
                {
                    //datos personales
                    viewModel.ID_Encriptado = UoW.Encriptador.Encriptar(_entidad.CIU_IDCiudadano);
                    viewModel.CIU_CURP = _entidad.CIU_CURP;
                    viewModel.CIU_Nombre = _entidad.CIU_Nombre;
                    viewModel.CIU_ApellidoPaterno = _entidad.CIU_ApellidoPaterno;
                    viewModel.CIU_ApellidoMaterno = _entidad.CIU_ApellidoMaterno;
                    viewModel.CIU_NumeroIdentificacion = _entidad.CIU_NumeroIdentificacion;
                    viewModel.CIU_IDGenero = _entidad.CIU_IDGenero;
                    viewModel.CIU_FechaNacimiento = _entidad.CIU_FechaNacimiento;
                    viewModel.CIU_IDEstado = _entidad.CIU_IDEstado;
                    viewModel.CIU_TiempoResidencia = _entidad.CIU_TiempoResidencia;
                    viewModel.CIU_IDGradoEstudios = _entidad.CIU_IDGradoEstudios;
                    viewModel.CIU_IDgrupoEtnico = _entidad.CIU_IDGrupoEtnico;
                    viewModel.CIU_IDEstadoCivil = _entidad.CIU_IDEstadoCivil;
                    viewModel.CIU_TelParticular = _entidad.CIU_TelParticular;
                    viewModel.CIU_TelTrabajo = _entidad.CIU_TelTrabajo;
                    viewModel.CIU_TelCelular = _entidad.CIU_TelCelular;
                    viewModel.CIU_TelRecados = _entidad.CIU_TelRecados;
                    viewModel.CIU_IDOrganizacionCivilFamilia = _entidad.CIU_IDOrganizacionCivilFamilia;
                    viewModel.CIU_IDEnfermedadCronica = _entidad.CIU_IDEnfermedadCronica;
                    viewModel.CIU_EnfermedadCronicaOtro = _entidad.CIU_EnfermedadCronicaOtro;
                    viewModel.CIU_IDDiscapacidad = _entidad.CIU_IDDiscapacidad;
                    viewModel.CIU_DiscapacidadOtro = _entidad.CIU_DiscapacidadOtro;
                    viewModel.CIU_IDGruposPrioritarios = _entidad.CIU_IDGruposPrioritarios;
                    viewModel.CIU_Proposito = _entidad.CIU_Proposito;
                    viewModel.CIU_CreditosOtorgados = _entidad.CIU_CreditosOtorgados;
                    viewModel.CIU_IngresoFamiliar = _entidad.CIU_IngresoFamiliar;
                    viewModel.CIU_IDOcupacion = _entidad.CIU_IDOcupacion;
                    viewModel.CIU_IDEstructuraFamiliar = _entidad.CIU_IDEstructuraFamiliar;
                    viewModel.CIU_NombreTrabajo = _entidad.CIU_NombreTrabajo;
                    viewModel.CIU_IDDomicilioTrabajo = _entidad.CIU_IDDomicilioTrabajo;
                    viewModel.CIU_CapacidadPago = _entidad.CIU_CapacidadPago;
                    viewModel.CIU_CorreoElectronico = _entidad.CIU_CorreoElectronico;
                    viewModel.CIU_IDDomicilio = _entidad.CIU_IDDomicilio;

                    //domicilio del ciudadano
                    ObtenerDomicilioCiudadano(_entidad.CIU_IDDomicilio, viewModel);

                    //Domicilio de trabajo
                    ObtenerDomicilio(_entidad.CIU_IDDomicilioTrabajo,viewModel.Domicilio_Trabajo);
                    //PAREJA
                    ObtenerPareja(_entidad.CIU_IDCiudadano, viewModel.Pareja);
                    //Deudor Solidario
                    ObtenerDeudorSolidario(_entidad.CIU_IDCiudadano, viewModel.DeudorSolidario);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }


            return viewModel;
        }

        public CiudadanoValidarViewModel BusquedaCURPNOMBRE(string cadenaBusqueda)
        {
            var viewModel = new CiudadanoValidarViewModel();

            try
            {
                var _listado = ListadoCURPNOMBRE(cadenaBusqueda);

                foreach (Ciudadano _cat in _listado)
                {
                    var _temp = new CiudadanosIndexListadoViewModel();

                    _temp.IDEncriptado = UoW.Encriptador.Encriptar(_cat.CIU_IDCiudadano);
                    _temp.CURP = _cat.CIU_CURP;
                    _temp.NombreCompleto = _cat.CIU_Nombre + " " + _cat.CIU_ApellidoPaterno + " " + _cat.CIU_ApellidoMaterno;

                    var _InfoCatalogo = this.UoW.Catalogos.ObtenerEntidad(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = _cat.CIU_IDGenero });

                    _temp.GeneroTexto = _InfoCatalogo.Descripcion;
                    _temp.DatosNacimiento = _cat.CIU_FechaNacimiento.Date.ToShortDateString().ToString();
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
        private DomicilioFormViewModel GetDomicilio( )
        {
            var _viewModel = new DomicilioFormViewModel();



            _viewModel.Vialidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_12_Vialidad", ID = 0 }).SelectListado();
            _viewModel.Alcaldia = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_Alcaldia", ID = 0 }).SelectListado();
            _viewModel.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.Boton = false;

            return _viewModel;
        }
        private CiudadanoParejaViewModel GetParejaCiudadano()
        {

            var _viewModel = new CiudadanoParejaViewModel();

            //Listas Datos Personales
            _viewModel.Genero = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
            _viewModel.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.RegimenPatrimonial = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_14_RegimenPatrimonial", ID = 0 }).SelectListado();
            return _viewModel;
        }
        private CiudadanoDeudorSolidarioViewModel GetDeudorSolidario()
        {
            var _viewModel = new CiudadanoDeudorSolidarioViewModel();
            //Listas Datos Personales
            _viewModel.Genero = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
            _viewModel.EstadoCivil = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.Ocupacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            _viewModel.DomicilioActual = GetDomicilio();
            _viewModel.DomicilioTrabajo = GetDomicilio();
            return _viewModel;

        }


        /* Funciones */
        public CiudadanoInsertarViewModel ObtenerCatalogos(CiudadanoInsertarViewModel viewModel)
        {
            //Listas
            viewModel.Genero = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
            viewModel.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
            viewModel.EstadoCivil = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
            viewModel.GradoEstudios = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_09_Escolaridad", ID = 0 }).SelectListado();
            viewModel.GrupoEtnico = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_10_GrupoEtnico", ID = 0 }).SelectListado();
            viewModel.Vialidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_12_Vialidad", ID = 0 }).SelectListado();
            viewModel.Alcaldia = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_Alcaldia", ID = 0 }).SelectListado();

            viewModel.TipoVivienda = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_TipoVivienda", ID = 0 }).SelectListado();
            viewModel.OrganizacionCivilFamilia = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
            viewModel.EstructuraFamiliar = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_66_EstructuraFamiliar", ID = 0 }).SelectListado();
            viewModel.EnfermedadCronica = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_17_EnfermedadCronica", ID = 0 }).SelectListado();
            viewModel.Discapacidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_16_Discapacidad", ID = 0 }).SelectListado();
            viewModel.GruposPrioritarios = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_18_GruposPrioritarios", ID = 0 }).SelectListado();
            viewModel.Ocupacion = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_15_Ocupacion", ID = 0 }).SelectListado();
            return viewModel;
        }
        public void Edit(CiudadanoInsertarViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                using (UoW.Ciudadano.TxScope = new TransactionScope())
                {
                    var _entidad = UoW.Ciudadano.Alta(new Ciudadano
                    {
                        CIU_ApellidoMaterno = viewModel.CIU_ApellidoMaterno,
                        CIU_ApellidoPaterno = viewModel.CIU_ApellidoPaterno,
                        CIU_CorreoElectronico = viewModel.CIU_CorreoElectronico,
                        CIU_CURP = viewModel.CIU_CURP,
                        CIU_CapacidadPago = viewModel.CIU_CapacidadPago,
                        CIU_CreditosOtorgados = viewModel.CIU_CreditosOtorgados,
                        CIU_DiscapacidadOtro = viewModel.CIU_DiscapacidadOtro,
                        CIU_EnfermedadCronicaOtro = viewModel.CIU_EnfermedadCronicaOtro,
                        CIU_FechaNacimiento = viewModel.CIU_FechaNacimiento,
                        CIU_IDCiudadano = Int32.Parse(this.UoW.Encriptador.Desencriptar(viewModel.ID_Encriptado)),
                        CIU_IDDiscapacidad = viewModel.CIU_IDDiscapacidad,
                        CIU_IDDomicilio = viewModel.CIU_IDDomicilio,
                        CIU_IDDomicilioTrabajo = viewModel.CIU_IDDomicilioTrabajo,
                        CIU_IDEnfermedadCronica = viewModel.CIU_IDEnfermedadCronica,
                        CIU_IDEstado = viewModel.CIU_IDEstado,
                        CIU_IDEstadoCivil = viewModel.CIU_IDEstadoCivil,
                        CIU_IDEstructuraFamiliar = viewModel.CIU_IDEstructuraFamiliar,
                        CIU_IDGenero = viewModel.CIU_IDGenero,
                        CIU_IDGradoEstudios = viewModel.CIU_IDGradoEstudios,
                        CIU_IDGrupoEtnico = viewModel.CIU_IDgrupoEtnico,
                        CIU_IDGruposPrioritarios = viewModel.CIU_IDGruposPrioritarios,
                        CIU_IDOcupacion = viewModel.CIU_IDOcupacion,
                        CIU_IDOrganizacionCivilFamilia = viewModel.CIU_IDOrganizacionCivilFamilia,
                        CIU_IngresoFamiliar = viewModel.CIU_IngresoFamiliar,
                        CIU_Nombre = viewModel.CIU_Nombre,
                        CIU_NombreTrabajo = viewModel.CIU_NombreTrabajo,
                        CIU_NumeroIdentificacion = viewModel.CIU_NumeroIdentificacion,
                        CIU_Proposito = viewModel.CIU_Proposito,
                        CIU_TelCelular = viewModel.CIU_TelCelular,
                        CIU_TelParticular = viewModel.CIU_TelCelular,
                        CIU_TelRecados = viewModel.CIU_TelRecados,
                        CIU_TelTrabajo = viewModel.CIU_TelTrabajo,
                        CIU_TiempoResidencia = viewModel.CIU_TiempoResidencia
                    });
                    UoW.Ciudadano.TxScope.Complete();
                }
            }
            if (!ModelState.IsValid)
            {

            }
        }



        public List<Ciudadano> ListadoCURPNOMBRE(string Cadena)
        {
            try
            {
                return UoW.Ciudadano.ObtenerListadoCURPNOMBRE(new Ciudadano { CIU_CURP = Cadena });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Listado");
            }

            return new List<Ciudadano>();
        }

        public CiudadanoInsertarViewModel ObtenerDomicilioCiudadano(int? id, CiudadanoInsertarViewModel viewModel)
        {
            try
            {
                var _entidad = UoW.DomicilioCiudadano.ObtenerEntidad(new DomicilioCiudadano
                {
                    DOMC_IDDomicilio = id

                });



                if (_entidad != null)
                {
                    viewModel.DOMC_IDVialidad = _entidad.DOMC_IDVialidad;
                    viewModel.DOMC_NombreVialidad = _entidad.DOMC_NombreVialidad;
                    viewModel.DOMC_NumeroExterior = _entidad.DOMC_NumeroExterior;
                    viewModel.DOMC_NumeroInterior = _entidad.DOMC_NumeroInterior;
                    viewModel.DOMC_Manzana = _entidad.DOMC_Manzana;
                    viewModel.DOMC_Lote = _entidad.DOMC_Lote;
                    viewModel.DOMC_Colonia = _entidad.DOMC_Colonia;
                    viewModel.DOMC_IDAlcaldia = _entidad.DOMC_IDAlcaldia;
                    viewModel.DOMC_CodigoPostal = _entidad.DOMC_CodigoPostal;
                    viewModel.DOMC_IDEstado = _entidad.DOMC_IDEstado;
                    viewModel.DOMC_Latitud = _entidad.DOMC_Latitud;
                    viewModel.DOMC_Longitud = _entidad.DOMC_Longitud;
                    viewModel.DOMC_MontoRenta = _entidad.DOMC_MontoRenta;
                    viewModel.DOMC_IDTipoVivienda = _entidad.DOMC_IDTipoVivienda;
                    viewModel.DOMC_Otro = _entidad.DOMC_Otro;


                    return viewModel;
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return viewModel;
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
                    _viewModel.DOM_Otro = _entidad.DOM_Otro;

                    return _viewModel;
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return _viewModel;
        }
        public CiudadanoParejaViewModel ObtenerPareja(int? id_solicitante, CiudadanoParejaViewModel _viewModel)
        {
            try
            {
               var _entidad= UoW.Pareja.ObtenerEntidad(new Pareja
                {
                    PAR_IDCiudadano = id_solicitante
                });
                if (_entidad != null)
                {
                    //datos personales
                    _viewModel.PAR_IDPareja = _entidad.PAR_IDPareja;
                    _viewModel.PAR_IDCiudadano = _entidad.PAR_IDCiudadano;

                    _viewModel.PAR_Nombre = _entidad.PAR_Nombre;
                    _viewModel.PAR_ApellidoPaterno = _entidad.PAR_ApellidoPaterno;
                    _viewModel.PAR_ApellidoMaterno = _entidad.PAR_ApellidoMaterno;

                    _viewModel.PAR_IDGenero = _entidad.PAR_IDGenero;
                    _viewModel.PAR_FechaNacimiento = _entidad.PAR_FechaNacimiento;
                    _viewModel.PAR_IDEstado = _entidad.PAR_IDEstado;
                    _viewModel.PAR_IDRegimen = _entidad.PAR_IDRegimen;

                    return _viewModel;
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return _viewModel;
        }
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
        


    }
 }
