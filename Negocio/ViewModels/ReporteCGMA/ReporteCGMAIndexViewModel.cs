using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.ReporteCGMA
{
   public class ReporteCGMAIndexViewModel
    {
        public List<ReporteCGMAIndexListadoViewModel> Listado { get; set; }

        public ReporteCGMAIndexViewModel()
        {
            Listado = new List<ReporteCGMAIndexListadoViewModel>();
        }

        
    }

    public class ReporteCGMAIndexListadoViewModel
    {
        public int      CGMA_ID { get; set; }
        public string   CGMA_Enviado { get; set; }
        public string   CGMA_Folio { get; set; }
        public int      CGMA_Tramite { get; set; }
        public string   CGMA_Modalidad { get; set; }
        public int      CGMA_TipoSolicitud { get; set; }
        public DateTime CGMA_FechaEntrada { get; set; }
        public int      CGMA_Atencion { get; set; }
        public int      CGMA_Calificacion { get; set; }
        public DateTime CGMA_FechaFinal { get; set; }
        public int      CGMA_Ente { get; set; }
        public string   CGMA_Unidad { get; set; }
        public string   CGMA_AAC { get; set; }
        public string   CGMA_Encargado { get; set; }
        public int      CGMA_Prioritario { get; set; }
        public int      CGMA_Sexo { get; set; }
        public int      CGMA_Personalidad { get; set; }
        public int      CGMA_Delegacion { get; set; }
        public int      CGMA_Vulnerable { get; set; }
        public string   CGMA_ConsEntregaCMV { get; set; }
        public string   CGMA_ClaveTramite { get; set; }
        public string   CGMA_FolioSolicitud { get; set; }
        public string   CGMA_NombreCiudadano { get; set; }
        public string CGMA_CalificacionFinal { get; set; }
    }
}
