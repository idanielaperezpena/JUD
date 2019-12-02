using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Negocio.ViewModels.DomicilioCiudadano
{
    public class DomicilioCiudadanoFormViewModel
    {

        public int? DOMC_IDDomicilio { get; set; }

        [CustomRequired]
        [Display(Name = "Vialidad *")]
        public int DOMC_IDVialidad { get; set; }

        [CustomRequired]
        [StringLength(40)]
        [Display(Name = "Nombre de la Vialidad *")]
        public string DOMC_NombreVialidad { get; set; }

        [Display(Name = "Número Exterior")]
        [StringLength(10)]
        public string DOMC_NumeroExterior { get; set; }

        [Display(Name = "Número Interior")]
        [StringLength(10)]
        public string DOMC_NumeroInterior { get; set; }

        [Display(Name = "Manzana")]
        [StringLength(10)]
        public string DOMC_Manzana { get; set; }

        [Display(Name = "Lote")]
        [StringLength(10)]
        public string DOMC_Lote { get; set; }

        [CustomRequired]
        [StringLength(50)]
        [Display(Name = "Colonia *")]
        public string DOMC_Colonia { get; set; }

        [CustomRequired]
        [Display(Name = "Alcaldía *")]
        public int DOMC_IDAlcaldia { get; set; }

        [Display(Name = "Código Postal")]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "El código postal no es válido")]
        public string DOMC_CodigoPostal { get; set; }

        [CustomRequired]
        [Display(Name = "Estado *")]
        public int DOMC_IDEstado { get; set; }

        [CustomRequired]
        [Display(Name = "Latitud *")]
        [RegularExpression("^(-?[1-8]?\\d(?:.\\d{1,18})?|90(?:.0{1,18})?)$", ErrorMessage = "La latitud no es válida")]
        public string DOMC_Latitud { get; set; }

        [CustomRequired]
        [Display(Name = "Longitud *")]
        [RegularExpression("^(-?(?:1[0-7]|[1-9])?\\d(?:.\\d{1,18})?|180(?:.0{1,18})?)$", ErrorMessage = "La longitud no es valida")]
        public string DOMC_Longitud { get; set; }

        [Display(Name = "Monto Renta")]
        public double DOMC_MontoRenta { get; set; }

        [CustomRequired]
        [Display(Name = "Tipo de Vivienda *")]
        public int DOMC_IDTipoVivienda { get; set; }

        [Display(Name = "Otro ")]
        [StringLength(100)]
        public string DOMC_Otro { get; set; }

        //Variables de Vista 
        public bool Boton { get; set; }
        public bool CreditoInicial { get; set; }


        public DomicilioCiudadanoFormViewModel() {
            Boton = true;
            CreditoInicial = false;
        }

        //Listas

        public ICustomSelectList<Entidades.Catalogos> Vialidad { get; set; }

        public ICustomSelectList<Entidades.Catalogos> Alcaldia { get; set; }

        public ICustomSelectList<Entidades.Catalogos> Estado { get; set; }

        public ICustomSelectList<Entidades.Catalogos> TipoVivienda { get; set; }
    }
}
