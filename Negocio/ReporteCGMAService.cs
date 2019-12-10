using Entidades;
using Entidades.Utilidades;
using Negocio.ViewModels.ReporteCGMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Negocio
{
   public class ReporteCGMAService : ServiceBase
    {
        public ReporteCGMAService(ModelStateDictionary modelState) : base(modelState)
        {
        }

        public ReporteCGMAIndexViewModel Index()
        {
            var _viewModel = new ReporteCGMAIndexViewModel();
            try
            {
                var _temp= UoW.ReporteCGMA.ObtenerListado(new ReporteCGMA());
               
                foreach (var item in _temp)
                {
                    var _listado = new ReporteCGMAIndexListadoViewModel();
                    _listado.CGMA_ID =                              item.CGMA_ID;
                    _listado.CGMA_Enviado =              item.CGMA_Enviado; 
                    _listado.CGMA_Folio =                        item.CGMA_Folio;
                    _listado.CGMA_Tramite =                      item.CGMA_Tramite;
                    _listado.CGMA_Modalidad                     =item.CGMA_Modalidad            ;     
                    _listado.CGMA_TipoSolicitud                 =item.CGMA_TipoSolicitud        ;
                    _listado.CGMA_FechaEntrada                  =item.CGMA_FechaEntrada         ;
                    _listado.CGMA_Atencion                      =item.CGMA_Atencion             ;
                    _listado.CGMA_Calificacion                  =item.CGMA_Calificacion         ;
                    _listado.CGMA_FechaFinal                    =item.CGMA_FechaFinal  ;
                    _listado.CGMA_Ente                          =item.CGMA_Ente                 ;
                    _listado.CGMA_Unidad                        =item.CGMA_Unidad               ;
                    _listado.CGMA_AAC                           =item.CGMA_AAC                  ;
                    _listado.CGMA_Encargado                     =item.CGMA_Encargado            ;
                    _listado.CGMA_Prioritario                   =item.CGMA_Prioritario          ;
                    _listado.CGMA_Sexo                          =item.CGMA_Sexo                 ;
                    _listado.CGMA_Personalidad                  =item.CGMA_Personalidad         ;
                    _listado.CGMA_Delegacion                    =item.CGMA_Delegacion           ;
                    _listado.CGMA_Vulnerable                    =item.CGMA_Vulnerable           ;
                    _listado.CGMA_ConsEntregaCMV                =item.CGMA_ConsEntregaCMV       ;
                    _listado.CGMA_ClaveTramite                  =item.CGMA_ClaveTramite         ;
                    _listado.CGMA_FolioSolicitud                =item.CGMA_FolioSolicitud       ;
                    _listado.CGMA_NombreCiudadano =              item.CGMA_NombreCiudadano;
                    _listado.CGMA_CalificacionFinal =            item.CGMA_CalificacionFinal;

                    _viewModel.Listado.Add(_listado);
                                     
                }
                
                return _viewModel;

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message + "Service : Index");

            }
            return _viewModel;
        }

        public ExcelFile IndexToExcel()
        {
        //    try
        //    {
                var _exporter = new EnumerableExcelWriter<ReporteCGMA>(UoW.ReporteCGMA.ObtenerListado(new ReporteCGMA()));

                return new ExcelFile("ReporteCGMA", false)
                {
                    FileBytes = _exporter.Exportar().ToArray()
                };
            //}
            //catch (Exception ex)
            //{
            //    ModelState.AddModelError(string.Empty, ex.Message);
            //}

            //return null;
        }
    }
}
