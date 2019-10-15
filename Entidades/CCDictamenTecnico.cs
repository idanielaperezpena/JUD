using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CCDictamenTecnico
    {
        public int? CCDT_IDDictamenTecnico { get; set; }
        public int CCDT_IDCreditoComplementario { get; set; }
        public int CCDT_Procedencia { get; set; }
        public string CCDT_MotivosProcedencia { get; set; }
        public float CCDT_MontoSugerido { get; set; }
        public DateTime CCDT_FechaDictaminacion { get; set; }
        public string CCDT_NoAsesorTecnico { get; set; }
        public string CCDT_UsuarioDominio { get; set; }
    }
}
