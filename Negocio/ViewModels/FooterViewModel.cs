using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels
{
    public class FooterViewModel
    {
        public Usuario Usuario { get; set; }
        public DateTime DateTime { get; set; }
        public string IPAddress { get; set; }
    }
}
