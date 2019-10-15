using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MCDictamenFinanciero
    {
        public int? MCDF_IDDictamenFinanciero { get; set; }
        public int MCDF_IDModificacionesCredito { get; set; }
        public int MCDF_Procedencia { get; set; }
        public string MCDF_MotivosProcedencia { get; set; }
        public int MCDF_IDUMA { get; set; }
        public int MCDF_NoMontoCreditoUMA { get; set; }
        public int MCDF_NoMesesAmortizacion { get; set; }
        public int MCDF_NoPagoUMA { get; set; }
        public DateTime MCDF_FechaDictaminacion { get; set; }
        public string MCDF_UsuarioDominio { get; set; }
    }
}
