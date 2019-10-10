using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace Negocio.ViewModels
{
    public class ExceptionIndexViewModel : PagedViewModel<ErrorLog>
    {
        [Display(Name = "Folio")]
        public string ERR_Folio { get; set; }
        [Display(Name = "Fecha")]
        public CalendarControl ERR_Fecha { get; set; }
        public string RegresarUrl { get; set; }

        public ExceptionIndexViewModel()
        {
            ERR_Fecha = new CalendarControl();
        }
    }
}
