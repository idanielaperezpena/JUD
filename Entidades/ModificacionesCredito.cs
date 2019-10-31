using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class ModificacionesCredito
    {
        public int? MC_IDModificacionesCredito { get; set; }
        public int MC_IDCreditoInicial { get; set; }
        public string MC_FolioSolicitud { get; set; }
        public DateTime MC_FechaCaptura { get; set; }
        public DateTime MC_FechaSolicitud { get; set; }
        public int MC_IDProblema { get; set; }
        public int MC_IDCiudadano { get; set; }
        public int MC_Procedencia { get; set; }
        public int MC_IDTipoTramite { get; set; }
        public float MC_Ingreso { get; set; }
    }
}
