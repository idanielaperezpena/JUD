using Entidades;
using Negocio.ViewModels.Ciudadanos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.CreditoInicial
{
    public class CreditoInicialInsertarViewModel
    {
        public int? CI_IDCreditoInicial { get; set; }

        [CustomRequired]
        [RegularExpression("^CI-[0-9]{4}$", ErrorMessage = "El formato del folio no es válido")]
        [Display(Name = "Folio Solicitud *")]
        public string CI_FolioSolicitud { get; set; }

        [CustomRequired]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Solicitud *")]
        public DateTime CI_FechaSolicitud { get; set; }

        [CustomRequired]
        [Display(Name = "Sección Electoral *")]
        public int? CI_IDSeccionElectoral { get; set; }

        [CustomRequired]
        [Display(Name = "Unidad Territorial *")]
        public string UnidadTerritorial { get; set; }


        public double CI_Ingreso { get; set; }
        [Display(Name = "¿Require comprobante de ingresos? *")]
        public bool CI_ComprobanteIngresos { get; set; }
        [Display(Name = "¿Require carta responsiva? *")]
        public bool CI_CartaResponsiva { get; set; }


        public int? CI_IDCiudadano { get; set; }
        public string CI_IDCiudadanoEncriptado { get; set; }
        public DateTime CI_FechaCaptura { get; set; }
        public int? CI_IDDomicilio { get; set; }

        public CiudadanoValidarViewModel ValidarCiudadano { get; set; }
        public CiudadanoInsertarViewModel CiudadanoInsertar { get; set; }

        public ICustomSelectList<SeccionElectoral> SeccionElectoral { get; set; }

        public CreditoInicialInsertarViewModel()
        {
            CI_FechaSolicitud = DateTime.Today;
        }

    }
}
