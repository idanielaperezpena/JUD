using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels
{
    public class ExceptionLogViewModel
    {
        public string MensajeView { get; set; }
        public string RegresarUrl { get; set; }
        public bool IsAjax { get; set; }
    }
}
