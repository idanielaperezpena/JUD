using Entidades;
using Entidades.Utilidades;
using Negocio.ViewModels;
using Negocio.ViewModels.Ciudadanos;
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

        public CiudadanosSolicitudesViewModel Insertar(string IDEncriptado)
        {
            var viewModel = new CiudadanosSolicitudesViewModel();

            try
            {
                var _ID_desencriptar = Int32.Parse(this.UoW.Encriptador.Desencriptar(IDEncriptado));

                viewModel.DatosPersonales = ObtenerDatosPersonales(_ID_desencriptar);

                //Listas Datos Personales
                viewModel.DatosPersonales.Genero = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_06_Genero", ID = 0 }).SelectListado();
                viewModel.DatosPersonales.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
                viewModel.DatosPersonales.EstadoCivil = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_13_CondicionesOrganizacionCivilFamilia", ID = 0 }).SelectListado();
                viewModel.DatosPersonales.GradoEstudios = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_09_Escolaridad", ID = 0 }).SelectListado();
                viewModel.DatosPersonales.GrupoEtnico = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_10_GrupoEtnico", ID = 0 }).SelectListado();

                //Listas Domicilio
                viewModel.Domicilio.Alcaldia = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_Alcaldia", ID = 0 }).SelectListado();
                viewModel.Domicilio.Vialidad = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_12_Vialidad", ID = 0 }).SelectListado();
                viewModel.Domicilio.Estado = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_EstadoRepublica", ID = 0 }).SelectListado();
                viewModel.Domicilio.TipoVivienda = UoW.Catalogos.ObtenerListado(new Catalogos { NombreCatalogo = "SIM_Cat_SN_TipoVivienda", ID = 0 }).SelectListado();

                viewModel.Domicilio.DOMC_IDAlcaldia = 10;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Mostrar");
            }

            return viewModel;
        }


        /* Funciones */
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


        public CiudadanoDatosPersonalesViewModel ObtenerDatosPersonales(int id)
        {
            try
            {
                var _entidad =  UoW.Ciudadano.ObtenerEntidad(new Ciudadano
                {
                    CIU_IDCiudadano = id
                });

                var viewModel = new CiudadanoDatosPersonalesViewModel();

                if (_entidad != null)
                {
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
                    viewModel.CIU_IDgrupoEtnico = _entidad.CIU_IDgrupoEtnico;
                    viewModel.CIU_IDEstadoCivil = _entidad.CIU_IDEstadoCivil;
                    viewModel.CIU_TelParticular = _entidad.CIU_TelParticular;
                    viewModel.CIU_TelTrabajo = _entidad.CIU_TelTrabajo;
                    viewModel.CIU_TelCelular = _entidad.CIU_TelCelular;
                    viewModel.CIU_TelRecados = _entidad.CIU_TelRecados;
                    
                    viewModel.CIU_CorreoElectronico = _entidad.CIU_CorreoElectronico;

                    return viewModel;
                }
                else
                {
                    viewModel.CIU_Nombre = "Es nulo";
                    return viewModel;
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return new CiudadanoDatosPersonalesViewModel();
        }

        public void Edit (CiudadanoDatosPersonalesViewModel viewModel)
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
                            CIU_CapacidadPago = 1,
                            CIU_CreditosOtorgados = false,
                            CIU_DiscapacidadOtro = "no",
                            CIU_EnfermedadCronicaOtro = "no",
                            CIU_FechaNacimiento = viewModel.CIU_FechaNacimiento,
                            CIU_IDCiudadano = Int32.Parse(this.UoW.Encriptador.Desencriptar(viewModel.ID_Encriptado)),
                            CIU_IDDiscapacidad = 1,
                            CIU_IDDomicilio = 1,
                            CIU_IDDomicilioTrabajo = 1,
                            CIU_IDEnfermedadCronica = 1,
                            CIU_IDEstado = viewModel.CIU_IDEstado,
                            CIU_IDEstadoCivil = viewModel.CIU_IDEstadoCivil,
                            CIU_IDEstructuraFamiliar = 1,
                            CIU_IDGenero = viewModel.CIU_IDGenero,
                            CIU_IDGradoEstudios = viewModel.CIU_IDGradoEstudios,
                            CIU_IDgrupoEtnico = viewModel.CIU_IDgrupoEtnico,
                            CIU_IDGruposPrioritarios = 1,
                            CIU_IDOcupacion = 1,
                            CIU_IDOrganizacionCivilFamilia = 1,
                            CIU_IngresoFamiliar = 1,
                            CIU_Nombre = viewModel.CIU_Nombre,
                            CIU_NombreTrabajo = "x",
                            CIU_NumeroIdentificacion = viewModel.CIU_NumeroIdentificacion,
                            CIU_Proposito = "x",
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

                    Console.WriteLine("###################################################################################################");
                }

            }
            
        }

    }

