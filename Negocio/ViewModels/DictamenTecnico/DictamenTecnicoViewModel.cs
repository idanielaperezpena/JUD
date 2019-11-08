using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.DictamenTecnico
{
    class DictamenTecnicoViewModel
    {
        
        public? int IDDictamenTecnico { get; set; }
        public int IDCreditoInicial { get; set; }

        [CustomRequired]
        [Display(Name = "Procedencia*")]
        public int IDProcedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Describa los motivos de procedencia o improcedencia*")]
        public string MotivosProcedencia { get; set; }

        [CustomRequired]
        [Display(Name = "Monto Sugerido*")]
        public double MontoSugerido { get; set; }

        [CustomRequired]
        [Display(Name = "Fecha de la Dictaminación*")]
        public DateTime FechaDictaminacion { get; set; }

        [CustomRequired]
        [Display(Name = "Asesor Técnico*")]
        public string NoAsesorTecnico { get; set; }

        [CustomRequired]
        public string UsuarioDominio { get; set; }


    }
}
