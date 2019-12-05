using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.ReporteCGMA
{
    class ReporteCGMAIndexViewModel
    {
        public List<ReporteCGMAIndexListadoViewModel> Listado { get; set; }
        public ReporteCGMAIndexViewModel(List<ReporteCGMAIndexListadoViewModel> listado)
        {
            Listado = listado;
        }

        
    }

    public class ReporteCGMAIndexListadoViewModel
    {
    }
}
