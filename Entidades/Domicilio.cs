using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Domicilio
    {
        public int? DOC_IDDomicilio { get; set; }
        public int DOC_IDVialidad { get; set; }
        public string DOC_NombreVialidad { get; set; }
        public string DOC_NumeroExterior { get; set; }
        public string DOC_NumeroInterior { get; set; }
        public string DOC_Manzana { get; set; }
        public string DOC_Lote { get; set; }
        public string DOC_Colonia { get; set; }
        public int DOC_IDAlcaldia { get; set; }
        public string DOC_CodigoPostal { get; set; }
        public int DOC_IDEstado { get; set; }
        public string DOC_Latitud { get; set; }
        public string DOC_Longitud { get; set; }
        public string DOC_Otro { get; set; }
    }
}
