using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.DictamenFinanciero
{
    class DictamenFinanciero
    {
        public int? IDDictamenFinanciero { get; set; }
        public int IDCreditoInicial { get; set; }

        [CustomRequired]
        [Display(Name = "Procedencia*")]
        public int Procedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Motivos Procedencia*")]
        public string MotivosProcedencia { get; set; }

        [CustomRequired]
        [Display(Name = "UMA*")]
        public int IDUMA { get; set; }

        [CustomRequired]
        [Display(Name = "Número Monto Credito*")]
        public int NoMontoCredito { get; set; }

        [CustomRequired]
        [Display(Name = "Número Meses Amortización*")]
        public int NoMesesAmortizacion { get; set; }

        [CustomRequired]
        [Display(Name = "Número de Pagos UMA*")]
        public int NoPagoUMA { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha Dictaminacion*")]
        public DateTime FechaDictaminacion { get; set; }

        public string UsuarioDominio { get; set; }

    }
}
