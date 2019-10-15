using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class CIDictamenFinanciero
    {
        public int? CIDF_IDDictamenFinanciero { get; set; }
        public int CIDF_IDCreditoInicial { get; set; }
        public int CIDF_Procedencia { get; set; }
        public string CIDF_MotivosProcedencia { get; set; }
        public int CIDF_IDUMA { get; set; }
        public int CIDF_NoMontoCreditoUMA { get; set; }
        public int CIDF_NoMesesAmortizacion { get; set; }
        public int CIDF_NoPagoUMA { get; set; }
        public DateTime CIDF_FechaDictaminacion { get; set; }
        public string CIDF_UsuarioDominio { get; set; }
    }
}
