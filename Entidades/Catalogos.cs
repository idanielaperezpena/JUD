using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Catalogos : ICustomSelectList
    {
        public string NombreCatalogo { get; set; }

        public int? ID{ get; set; }
        public string Clave { get; set; }
        public int ClaveCGMA { get; set; }
        public string Tipo { get; set; }
        public string Descripcion{ get; set; }
        public bool Activo { get; set; }


        public string DataValueField => "ID";
        public string DataTextField => "Descripcion";

    }
}
