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

        public int? ID{ get; set; }
        public int Clave { get; set; }
        public int ClaveCGMA { get; set; }
        public string Descripcion{ get; set; }
        public bool Activo { get; set; }

    }
}
