using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class CreditoInicial
    {
        public int? CI_IDCreditoInicial { get; set; }
        public string CI_FolioSolicitud { get; set; }
        public int? CI_IDCiudadano { get; set; }
        public DateTime CI_FechaCaptura { get; set; }
        public DateTime CI_FechaSolicitud { get; set; }
        public int? CI_IDSeccionElectoral { get; set; }
        public int? CI_IDDomicilio { get; set; }
        public int? CI_IDSesionComite { get; set; }
        public string CI_IDMejoramiento { get; set; }
        public string CI_FolioCredito { get; set; }
        public float CI_Ingreso { get; set; }
        public bool CI_ComprobanteIngresos { get; set; }
        public bool CI_CartaResponsiva { get; set; }
    }
}
