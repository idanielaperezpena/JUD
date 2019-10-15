using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CSDictamenSocial
    {
        public int? CSDS_IDDictamenSocial { get; set; }
        public int CSDS_IDCreditoSustentabilidad { get; set; }
        public int CSDS_IDTipoVivienda { get; set; }
        public int CSDS_NoFamiliasLote { get; set; }
        public int CSDS_NoFamiliasVivienda { get; set; }
        public int CSDS_NoViviendasLote { get; set; }
        public int CSDS_NoPersonasVivienda { get; set; }
        public int CSDS_IDServicioAgua { get; set; }
        public int CSDS_IDServicioDrenaje { get; set; }
        public int CSDS_IDServicioElectrico { get; set; }
        public bool CSDS_Desdoblamiento { get; set; }
        public bool CSDS_BanoCompartido { get; set; }
        public bool CSDS_CocinaCompartido { get; set; }
        public int CSDS_IDHacinamiento { get; set; }
        public int? CSDS_IDInsalubridad { get; set; }
        public string CSDS_OtroInsalubridad { get; set; }
        public DateTime CSDS_FechaVisita { get; set; }
        public string CSDS_Observaciones { get; set; }
        public string CSDS_NoEmpleadoVisita { get; set; }
        public int CSDS_Procedencia { get; set; }
        public int CSDS_IDVulnerabilidad { get; set; }
        public string CSDS_MotivosProcedencia { get; set; }
        public DateTime CSDS_FechaDictaminacion { get; set; }
        public string CSDS_UsuarioDominio { get; set; }
    }
}
