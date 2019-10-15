using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CCDictamenSocial
    {
        public int? CCDS_IDDictamenSocial { get; set; }
        public int CCDS_IDCreditoComplementario { get; set; }
        public int CCDS_IDTipoVivienda { get; set; }
        public int CCDS_NoFamiliasLote { get; set; }
        public int CCDS_NoFamiliasVivienda { get; set; }
        public int CCDS_NoViviendasLote { get; set; }
        public int CCDS_NoPersonasVivienda { get; set; }
        public int CCDS_IDServicioAgua { get; set; }
        public int CCDS_IDServicioDrenaje { get; set; }
        public int CCDS_IDServicioElectrico { get; set; }
        public bool CCDS_Desdoblamiento { get; set; }
        public bool CCDS_BanoCompartido { get; set; }
        public bool CCDS_CocinaCompartido { get; set; }
        public int CCDS_IDHacinamiento { get; set; }
        public int? CCDS_IDInsalubridad { get; set; }
        public string CCDS_OtroInsalubridad { get; set; }
        public DateTime CCDS_FechaVisita { get; set; }
        public string CCDS_Observaciones { get; set; }
        public string CCDS_NoEmpleadoVisita { get; set; }
        public int CCDS_Procedencia { get; set; }
        public int CCDS_IDVulnerabilidad { get; set; }
        public string CCDS_MotivosProcedencia { get; set; }
        public DateTime CCDS_FechaDictaminacion { get; set; }
        public string CCDS_UsuarioDominio { get; set; }
    }
}
