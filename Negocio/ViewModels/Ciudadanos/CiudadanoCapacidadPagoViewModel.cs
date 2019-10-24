using Entidades;
using Negocio.ViewModels.DomicilioCiudadano;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.Ciudadanos
{
    public class CiudadanoCapacidadPagoViewModel
    {
        [CustomRequired]
        [Display(Name = " De su ingreso familiar mensual,< br />  ¿Cuánto podrá destinar para el pago del crédito ? *")]
        public double CIU_CapacidadPago { get; set; }
    }
}
