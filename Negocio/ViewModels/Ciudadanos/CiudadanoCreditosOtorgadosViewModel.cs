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
    public class CiudadanoCreditosOtorgadosViewModel
    {
        [CustomRequired]
        [Display(Name = "Proposito *")]
        public string CIU_Proposito { get; set; }

        [CustomRequired]
        [Display(Name = "Creditos Otorgados *")]
        public bool CIU_CreditosOtorgados { get; set; }

    }
}
