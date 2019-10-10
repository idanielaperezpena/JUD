using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Modulo
    {
        public int? MDL_Id { get; set; }
        public int? MDL_Parent { get; set; }
        public int? PMDL_Id { get; set; }
        public int? TMNU_Id { get; set; }

        public string MDL_Nombre { get; set; }
        public string MDL_Controller { get; set; }
        public string MDL_Action { get; set; }
        public string MDL_Icono { get; set; }

        public List<Modulo> SubModulos { get; set; }
        public List<EnumModuloPermiso> Permisos { get; set; }

        public EnumModulo TipoModulo => MDL_Id.ParseTo<EnumModulo>();
        public EnumModuloPermiso TipoPermiso => PMDL_Id.ParseTo<EnumModuloPermiso>();
        public EnumTipoMenu TipoMenu => TMNU_Id.ParseTo<EnumTipoMenu>();

        public Modulo()
        {
            SubModulos = new List<Modulo>();
            Permisos = new List<EnumModuloPermiso>();
        }

        public bool this[EnumModuloPermiso accion]
        {
            get { return Permisos.Exists(f => f == accion); }
        }
    }
}
