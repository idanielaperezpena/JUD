using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class CSDictamenFinanciero
    {
        public int? CSDF_IDDictamenFinanciero { get; set; }
        public int CSDF_IDCreditoSustentabilidad { get; set; }
        public int CSDF_Procedencia { get; set; }
        public string CSDF_MotivosProcedencia { get; set; }
        public int CSDF_IDUMA { get; set; }
        public int CSDF_NoMontoCreditoUMA { get; set; }
        public int CSDF_NoMesesAmortizacion { get; set; }
        public int CSDF_NoPagoUMA { get; set; }
        public DateTime CSDF_FechaDictaminacion { get; set; }
        public string CSDF_UsuarioDominio { get; set; }
    }
}
