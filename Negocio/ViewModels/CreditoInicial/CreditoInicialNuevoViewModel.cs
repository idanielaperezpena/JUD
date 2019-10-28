using Negocio.ViewModels.Ciudadanos;
using Negocio.ViewModels.Domicilio;
using Negocio.ViewModels.DomicilioCiudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.CreditoInicial
{
    public class CreditoInicialNuevoViewModel
    {
        public CiudadanoDatosPersonalesViewModel DatosPersonales { get; set; }
        public CiudadanoParejaViewModel Pareja { get; set; }
        public DomicilioFormViewModel Domicilio { get; set; }
        public DomicilioCiudadanoFormViewModel DomicilioCiudadano { get; set; }
        public CiudadanoCreditosOtorgadosViewModel CreditosOtorgados { get; set; } 
        public CiudadanoComposicionFamiliarViewModel ComposicionFamiliar { get; set; }
        public CiudadanoDeudorSolidarioViewModel DeudorSolidatio { get; set; }
        public CiudadanoCapacidadPagoViewModel CapacidadPago { get; set; }

        public CreditoInicialNuevoViewModel() {
            DatosPersonales = new CiudadanoDatosPersonalesViewModel();
            Pareja = new CiudadanoParejaViewModel();
            Domicilio = new DomicilioFormViewModel();
            DomicilioCiudadano = new DomicilioCiudadanoFormViewModel();
            CreditosOtorgados = new CiudadanoCreditosOtorgadosViewModel();
            ComposicionFamiliar = new CiudadanoComposicionFamiliarViewModel();
            DeudorSolidatio = new CiudadanoDeudorSolidarioViewModel();
            CapacidadPago = new CiudadanoCapacidadPagoViewModel();
        }
    }
}
