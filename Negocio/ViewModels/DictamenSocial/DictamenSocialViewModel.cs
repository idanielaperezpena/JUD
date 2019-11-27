using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.DictamenSocial
{
    public class DictamenSocialViewModel
    {
        public string TipoCredito { get; set; }
        public int? IDDictamenSocial { get; set; }
        public int IDCredito { get; set; }

        [CustomRequired]
        [Display(Name = "Vivienda en *")]
        public int IDTipoPredio { get; set; }

        [CustomRequired]
        [Display(Name = "Característica del Predio *")]
        public int IDCaracteristicaPredio { get; set; }

        [CustomRequired]
        [Display(Name = "No. de Viviendas en el lote *")]
        public int NoViviendasLote { get; set; }

        [CustomRequired]
        [Display(Name = "No. de Familias que habitan en el lote *")]
        public int NoFamiliasLote { get; set; }

        [CustomRequired]
        [Display(Name = "No. de Familias que habitan la vivienda que ocupa el (la) solicitante *")]
        public int NoFamiliasVivienda { get; set; }
        
        [CustomRequired]
        [Display(Name = "No. de Personas que habitan la vivienda que ocupa el (la) solicitante incluyéndola(o) *")]
        public int NoPersonasVivienda { get; set; }

        [CustomRequired]
        [Display(Name = "Servicio de Agua *")]
        public int IDServicioAgua { get; set; }

        [CustomRequired]
        [Display(Name = "Servicio de Drenaje *")]
        public int IDServicioDrenaje { get; set; }

        [CustomRequired]
        [Display(Name = "Servicio de Energía eléctrica *")]
        public int IDServicioElectrico { get; set; }

        [CustomRequired]
        [Display(Name = "Desdoblamiento Familiar *")]
        public bool Desdoblamiento { get; set; }

        [CustomRequired]
        [Display(Name = "Baño Compartido *")]
        public bool BanoCompartido { get; set; }

        [CustomRequired]
        [Display(Name = "Cocina Compartida *")]
        public bool CocinaCompartida { get; set; }

        [CustomRequired]
        [Display(Name = "Hacinamiento *")]
        public int IDHacinamiento { get; set; }

        [CustomRequired]
        [Display(Name = "Insalubridad *")]
        public int IDInsalubridad { get; set; }

        [Display(Name = "Otro (especifique)")]
        public string OtroInsalubridad { get; set; }

        [CustomRequired]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Visita domiciliaria realizada el: *")]
        public DateTime FechaVisita { get; set; }

        [Display(Name = "Se verificó que la (el) solicitante *")]
        public string Observaciones { get; set; }

        [CustomRequired]
        [Display(Name = "No. Empleada(o)*")]
        public string NoEmpleadoVisita { get; set; }

        [CustomRequired]
        [Display(Name = "Cumple con el perfil socioeconómico para ser sujeto de crédito*")]
        public int Procedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Presenta situaciones de vulnerabilidad*")]
        public int IDVulnerabilidad { get; set; }

        [CustomRequired]
        [Display(Name = "Motivos*")]
        public string MotivosProcedencia { get; set; }

        [CustomRequired]
        [DataType(DataType.Date, ErrorMessage = "Favor de ingresar un formato correcto para el campo de fecha (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de la Dictaminación*")]
        public DateTime FechaDictaminacion { get; set; }

        
        public string UsuarioDominio { get; set; }
        #region Listas

        public ICustomSelectList<Entidades.Catalogos> TipoPredio { get; set; }
        public ICustomSelectList<Entidades.Catalogos> CaracteristicasPredio { get; set; }
        public ICustomSelectList<Entidades.Catalogos> ServicioAgua { get; set; }
        public ICustomSelectList<Entidades.Catalogos> ServicioDrenaje { get; set; }
        public ICustomSelectList<Entidades.Catalogos> ServicioElectrico { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Hacinamiento { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Insalubridad { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Dictaminacion { get; set; }
        public ICustomSelectList<Entidades.Catalogos> Vulnerabilidad { get; set; }
        #endregion
    }
}
