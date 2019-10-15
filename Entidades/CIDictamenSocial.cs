using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class CIDictamenSocial
    {
        public int? CIDS_IDDictamenSocial { get; set; } 
        public int CIDS_IDCreditoInicial { get; set; }
        public int CIDS_IDTipoVivienda { get; set; }
        public int CIDS_NoFamiliasLote { get; set; }
        public int CIDS_NoFamiliasVivienda { get; set; }
        public int CIDS_NoViviendasLote { get; set; }
        public int CIDS_NoPersonasVivienda { get; set; }
        public int CIDS_IDServicioAgua { get; set; }
        public int CIDS_IDServicioDrenaje { get; set; }
        public int CIDS_IDServicioElectrico { get; set; }
        public bool CIDS_Desdoblamiento { get; set; }
        public bool CIDS_BanoCompartido { get; set; }
        public bool CIDS_CocinaCompartido { get; set; }
        public int CIDS_IDHacinamiento { get; set; }
        public int? CIDS_IDInsalubridad { get; set; }
        public string CIDS_OtroInsalubridad { get; set; }
        public DateTime CIDS_FechaVisita { get; set; }
        public string CIDS_Observaciones { get; set; }
        public string CIDS_NoEmpleadoVisita { get; set; }
        public int CIDS_Procedencia { get; set; }
        public int CIDS_IDVulnerabilidad { get; set; }
        public string CIDS_MotivosProcedencia { get; set; }
        public DateTime CIDS_FechaDictaminacion { get; set; }
        public string CIDS_UsuarioDominio { get; set; }
    }
}
