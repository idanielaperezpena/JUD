using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CCDictamenFinanciero
    {
        public int? CCDF_IDDictamenFinanciero { get; set; }
        public int CCDF_IDCreditoComplementario { get; set; }
        public int CCDF_Procedencia { get; set; }
        public string CCDF_MotivosProcedencia { get; set; }
        public int CCDF_IDUMA { get; set; }
        public int CCDF_NoMontoCreditoUMA { get; set; }
        public int CCDF_NoMesesAmortizacion { get; set; }
        public int CCDF_NoPagoUMA { get; set; }
        public DateTime CCDF_FechaDictaminacion { get; set; }
        public string CCDF_UsuarioDominio { get; set; }
    }
}
