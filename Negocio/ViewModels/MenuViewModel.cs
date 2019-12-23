using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels
{
    public class MenuViewModel
    {
        public Usuario Usuario { get; set; }

        public IEnumerable<Modulo> ModulosAdmin { get; set; }
        public IEnumerable<Modulo> ModulosUsuario { get; set; }
    }
}
