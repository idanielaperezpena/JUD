using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class MCDictamenTecnico
    {
        public int? MCDT_IDDictamenTecnico { get; set; }
        public int MCDT_IDModificacionesCredito { get; set; }
        public int MCDT_Procedencia { get; set; }
        public string MCDT_MotivosProcedencia { get; set; }
        public float MCDT_MontoSugerido { get; set; }
        public DateTime MCDT_FechaDictaminacion { get; set; }
        public string MCDT_NoAsesorTecnico { get; set; }
        public string MCDT_UsuarioDominio { get; set; }
    }
}
