using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Negocio.ViewModels.Domicilio
{
    public class DomicilioFormViewModel
    {
        public int? DOM_IDDomicilio { get; set; }

        [CustomRequired]

        [Display(Name = "Tipo de Vialidad *")]
        public int DOM_IDVialidad { get; set; }

        [CustomRequired]
        [StringLength(40)]
        [Display(Name = "Vialidad *")]
        public string DOM_NombreVialidad { get; set; }

        [CustomRequired]
        [StringLength(10)]
        [Display(Name = "Número Exterior *")]
        public string DOM_NumeroExterior { get; set; }

        [StringLength(10)]
        [Display(Name = "Número Interior ")]
        public string DOM_NumeroInterior { get; set; }

        [StringLength(10)]
        [Display(Name = "Manzana ")]
        public string DOM_Manzana { get; set; }

        [StringLength(10)]
        [Display(Name = "Lote ")]
        public string DOM_Lote { get; set; }

        [CustomRequired]
        [StringLength(50)]
        [Display(Name = "Colonia *")]
        public string DOM_Colonia { get; set; }

        [CustomRequired]
        [Display(Name = "Alcaldía *")]
        public int DOM_IDAlcaldia { get; set; }

        [CustomRequired]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "El código postal no es válido")]
        [Display(Name = "Código Postal *")]
        public string DOM_CodigoPostal { get; set; }

        [CustomRequired]
        [Display(Name = "Estado *")]
        public int DOM_IDEstado { get; set; }

        [Display(Name = "Latitud")]
        [RegularExpression("^(-?[1-8]?\\d(?:.\\d{1,18})?|90(?:.0{1,18})?)$", ErrorMessage = "La latitud no es válida")]
        public string DOM_Latitud { get; set; }

        [Display(Name = "Longitud")]
        [RegularExpression("^(-?(?:1[0-7]|[1-9])?\\d(?:.\\d{1,18})?|180(?:.0{1,18})?)$", ErrorMessage = "La longitud no es válida")]
        public string DOM_Longitud { get; set; }

        


        //Variables de Vista 
        public bool Boton { get; set; }


        public DomicilioFormViewModel()
        {
            Boton = true;
        }
        //Listas

        public ICustomSelectList<Entidades.Catalogos> Vialidad { get; set; }

        public ICustomSelectList<Entidades.Catalogos> Alcaldia { get; set; }

        public ICustomSelectList<Entidades.Catalogos> Estado { get; set; }

      

    }
}
