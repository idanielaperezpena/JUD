using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class DomicilioCredito
    {
        public int? DOMC_IDDomicilio { get; set; }
        public int DOMC_IDVialidad { get; set; }
        public string DOMC_NombreVialidad { get; set; }
        public string DOMC_NumeroExterior { get; set; }
        public string DOMC_NumeroInterior { get; set; }
        public string DOMC_Manzana { get; set; }
        public string DOMC_Lote { get; set; }
        public string DOMC_Colonia { get; set; }
        public int DOMC_IDAlcaldia { get; set; }
        public string DOMC_CodigoPostal { get; set; }
        public int DOMC_IDEstado { get; set; }
        public string DOMC_Latitud { get; set; }
        public string DOMC_Longitud { get; set; }
        public float DOMC_MontoRenta { get; set; }
        public string DOMC_Otro { get; set; }
    }
}
