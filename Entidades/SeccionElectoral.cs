using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SeccionElectoral : ICustomSelectList
    {
        public string NombreCatalogo { get; set; }

        public int? ID { get; set; }
        public string ClaveSE { get; set; }
        public string ClaveUT { get; set; }


        public string DataValueField => "ID";
        public string DataTextField => "ClaveSE";
    }
}
