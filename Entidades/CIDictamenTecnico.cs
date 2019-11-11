using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class CIDictamenTecnico
    {
        public int? CIDT_IDDictamenTecnico { get; set; }
        public int CIDT_IDCreditoInicial { get; set; }
        public int CIDT_Procedencia { get; set; }
        public string CIDT_MotivosProcedencia { get; set; }
        public double CIDT_MontoSugerido { get; set; }
        public DateTime CIDT_FechaDictaminacion { get; set; }
        public string CIDT_NoAsesorTecnico { get; set; }
        public string CIDT_UsuarioDominio { get; set; }
    }
}
