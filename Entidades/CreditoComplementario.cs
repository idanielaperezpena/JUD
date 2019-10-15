using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class CreditoComplementario
    {
        public int? CC_IDCreditoComplementario { get; set; }
        public int CC_IDCreditoInicial { get; set; }
        public string CC_FolioSolicitud { get; set; }
        public DateTime CC_FechaCaptura { get; set; }
        public DateTime CC_FechaSolicitud { get; set; }
        public int? CC_NoSesionComite { get; set; }
        public int? CC_IDMejoramiento { get; set; }
        public float CC_Ingreso { get; set; }
    }
}
