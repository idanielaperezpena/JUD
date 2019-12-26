using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.Principal
{
    public class PrincipalIndexViewModel
    {
        public int TotalCreditos { get; set; }

        public int TotalCreditosTerminados { get; set; }

        public int TotalCreditosDictaminados { get; set; }

        public int TotalCreditosNuevos { get; set; }

        public Usuario user { get; set; }
    }
}
