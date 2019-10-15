using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class CreditoSustentabilidad
    {
        public int? CS_IDCreditoSustentabilidad { get; set; }
        public int CS_IDCreditoInicial { get; set; }
        public string CS_FolioSolicitud { get; set; }
        public DateTime CS_FechaCaptura { get; set; }
        public DateTime CS_FechaSolicitud { get; set; }
    }
}
