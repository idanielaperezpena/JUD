using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int? USU_Id { get; set; }
        public string USU_Usuario { get; set; }
        public string USU_Password { get; set; }

        public int? MDL_Default { get; set; }
        public string MDL_DefaultController { get; set; }
        public string MDL_DefaultAction { get; set; }
        public string UrlDefault { get; set; }
    }
}
