using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DomicilioCiudadano
    {
        public int? DOMC_IDDomicilioCiudadano { get; set; }
        public int? DOMC_IDCiudadano { get; set; }
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
        public double DOMC_MontoRenta { get; set; }
        public int DOMC_IDTipoVivienda { get; set; }
        public string DOMC_Otro { get; set; }

        public override string ToString()
        {
            string _domicilioCompleto = string.Empty;
            _domicilioCompleto += "Vialidad: " + DOMC_NombreVialidad + ", ";

            if(!string.IsNullOrEmpty(DOMC_NumeroExterior))
                _domicilioCompleto += "Número Exterior: " + DOMC_NumeroExterior + ", ";
            if (!string.IsNullOrEmpty(DOMC_NumeroInterior))
                _domicilioCompleto += "Número Interior: " + DOMC_NumeroInterior + ", ";
            if (!string.IsNullOrEmpty(DOMC_Manzana))
                _domicilioCompleto += "MZ: " + DOMC_Manzana + ", ";
            if(!string.IsNullOrEmpty(DOMC_Lote))
                _domicilioCompleto += "LT: " + DOMC_Manzana + ", ";
            _domicilioCompleto += "Colonia" + DOMC_Colonia + ", ";
            _domicilioCompleto += "Código Postal" + DOMC_CodigoPostal + ", ";

            return _domicilioCompleto.ToUpper();
            
        }
    }
}
