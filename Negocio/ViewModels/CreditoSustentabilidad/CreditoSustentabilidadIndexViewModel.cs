﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.CreditoSustentabilidad
{
    public class CreditoSustentabilidadIndexViewModel
    {

        public List<CreditoSustentabilidadIndexListadoViewModel> Listado { get; set; }

        public List<CreditoSustentabilidadIndexCIListadoViewModel> ListadoCI { get; set; }

        public Usuario user { get; set; }

        public CreditoSustentabilidadIndexViewModel()
        {
            Listado = new List<CreditoSustentabilidadIndexListadoViewModel>();
            ListadoCI = new List<CreditoSustentabilidadIndexCIListadoViewModel>();
        }

    }

    public class CreditoSustentabilidadIndexListadoViewModel
    {
        

        public int? CS_IDCreditoSustentabilidad { get; set; }

        public int CS_IDCreditoInicial { get; set; }

        [Display(Name = "Folio Solicitud")]
        public string CS_FolioSolicitud { get; set; }

        [Display(Name = "Folio Credito Inicial")]
        public string CI_FolioSolicitud { get; set; }

        [Display(Name = "CURP")]
        public string CI_CURP { get; set; }

        [Display(Name = "Nombre del Ciudadano")]
        public string NombreCiudadano { get; set; }

        [Display(Name = "Fecha de solicitud")]
        public String CS_FechaSolicitud { get; set; }

        [Display(Name = "Dictamen Social")]
        public string[] ImgDS { get; set; }

        [Display(Name = "Dictamen Técnico")]
        public string[] ImgDT { get; set; }

        [Display(Name = "Dictamen Jurídico")]
        public string[] ImgDJ { get; set; }

        [Display(Name = "Dictamen Financiero")]
        public string[] ImgDF { get; set; }
    }

    public class CreditoSustentabilidadIndexCIListadoViewModel
    {

        public int? CI_ID { get; set; }

        [Display(Name = "Folio Solicitud")]
        public string CI_FolioSolicitud { get; set; }

        [Display(Name = "CURP")]
        public string CURPCiudadano { get; set; }

        [Display(Name = "Nombre del Ciudadano")]
        public string NombreCiudadano { get; set; }

        [Display(Name = "Fecha de solicitud")]
        public String CI_FechaSolicitud { get; set; }

        [Display(Name = "Sección Electoral")]
        public int? CI_IDSeccionElectoral { get; set; }
        public string IDEncriptado { get; internal set; }
    }


}
