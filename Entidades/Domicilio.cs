using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Domicilio
    {
        public int? DOM_IDDomicilio { get; set; }
        public int DOM_IDVialidad { get; set; }
        public string DOM_NombreVialidad { get; set; }
        public string DOM_NumeroExterior { get; set; }
        public string DOM_NumeroInterior { get; set; }
        public string DOM_Manzana { get; set; }
        public string DOM_Lote { get; set; }
        public string DOM_Colonia { get; set; }
        public int DOM_IDAlcaldia { get; set; }
        public string DOM_CodigoPostal { get; set; }
        public int DOM_IDEstado { get; set; }
        public string DOM_Latitud { get; set; }
        public string DOM_Longitud { get; set; }
        public string DOM_Otro { get; set; }

    }
}
