using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Catalogos
    {
        public string NombreCatalogo { get; set; }

        public int? IDEsc { get; set; }
        public int EscClave { get; set; }
        public string EscGrado { get; set; }
        public bool? EscActivo { get; set; }

    }
}
