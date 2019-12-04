using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UnidadTerritorial : ICustomSelectList
    {

        public int? ID { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int ClaveMesa { get; set; }
        public int ClaveAlcaldia { get; set; }

        public string DataValueField => "ID";
        public string DataTextField => "Descripcion";
    }
}
