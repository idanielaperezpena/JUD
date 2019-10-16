using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pareja
    {
        public int? PAR_IDPareja { get; set; }
        public int PAR_IDCiudadano { get; set; }
        public string PAR_Nombre { get; set; }
        public string PAR_ApellidoPaterno { get; set; }
        public string PAR_ApellidoMaterno { get; set; }
        public int PAR_IDGenero { get; set; }
        public int PAR_IDEstado { get; set; }
        public DateTime PAR_FechaNacimiento { get; set; }

    }
}
