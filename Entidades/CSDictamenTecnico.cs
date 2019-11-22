using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CSDictamenTecnico
    {
        public int? CSDT_IDDictamenTecnico { get; set; }
        public int CSDT_IDCreditoSustentabilidad { get; set; }
        public int CSDT_Procedencia { get; set; }
        public string CSDT_MotivosProcedencia { get; set; }
        public double CSDT_MontoSugerido { get; set; }
        public DateTime CSDT_FechaDictaminacion { get; set; }
        public string CSDT_NoAsesorTecnico { get; set; }
        public string CSDT_UsuarioDominio { get; set; }
    }
}
