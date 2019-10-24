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

        public string DOMC_IDDomicilio { get; set; }

        [CustomRequired]
        [Display(Name = "Vialidad *")]
        public int DOMC_IDVialidad { get; set; }

        [CustomRequired]
        [Display(Name = "Nombre de la Vialidad *")]
        public string DOMC_NombreVialidad { get; set; }

        [Display(Name = "Numero Exterior")]
        public string DOMC_NumeroExterior { get; set; }

        [Display(Name = "Nombre Interior")]
        public string DOMC_NumeroInterior { get; set; }

        [Display(Name = "Manzana")]
        public string DOMC_Manzana { get; set; }

        [Display(Name = "Lote")]
        public string DOMC_Lote { get; set; }

        [CustomRequired]
        [Display(Name = "Colonia *")]
        public string DOMC_Colonia { get; set; }

        [CustomRequired]
        [Display(Name = "Alcaldia *")]
        public int DOMC_IDAlcaldia { get; set; }

        [Display(Name = "Codigo Postal")]
        public string DOMC_CodigoPostal { get; set; }

        [CustomRequired]
        [Display(Name = "Estado *")]
        public int DOMC_IDEstado { get; set; }

        [CustomRequired]
        [Display(Name = "Latitud *")]
        public string DOMC_Latitud { get; set; }

        [CustomRequired]
        [Display(Name = "Longitud *")]
        public string DOMC_Longitud { get; set; }

        [Display(Name = "Monto Renta")]
        public double DOMC_MontoRenta { get; set; }

        [CustomRequired]
        [Display(Name = "Tipo de Vivienda *")]
        public int DOMC_IDTipoVivienda { get; set; }

        [Display(Name = "Otro ")]
        public string DOMC_Otro { get; set; }

        //Listas

        public ICustomSelectList<Entidades.Catalogos> Vialidad { get; set; }

        public ICustomSelectList<Entidades.Catalogos> Alcaldia { get; set; }

        public ICustomSelectList<Entidades.Catalogos> Estado { get; set; }

        public ICustomSelectList<Entidades.Catalogos> TipoVivienda { get; set; }
    }
}
