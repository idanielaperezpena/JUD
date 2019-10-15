using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class MCDictamenSocial
    {
        public int? MCDS_IDDictamenSocial { get; set; }
        public int MCDS_IDModificacionesCredito { get; set; }
        public int MCDS_IDTipoVivienda { get; set; }
        public int MCDS_NoFamiliasLote { get; set; }
        public int MCDS_NoFamiliasVivienda { get; set; }
        public int MCDS_NoViviendasLote { get; set; }
        public int MCDS_NoPersonasVivienda { get; set; }
        public int MCDS_IDServicioAgua { get; set; }
        public int MCDS_IDServicioDrenaje { get; set; }
        public int MCDS_IDServicioElectrico { get; set; }
        public bool MCDS_Desdoblamiento { get; set; }
        public bool MCDS_BanoCompartido { get; set; }
        public bool MCDS_CocinaCompartido { get; set; }
        public int MCDS_IDHacinamiento { get; set; }
        public int? MCDS_IDInsalubridad { get; set; }
        public string MCDS_OtroInsalubridad { get; set; }
        public DateTime MCDS_FechaVisita { get; set; }
        public string MCDS_Observaciones { get; set; }
        public string MCDS_NoEmpleadoVisita { get; set; }
        public int MCDS_Procedencia { get; set; }
        public int MCDS_IDVulnerabilidad { get; set; }
        public string MCDS_MotivosProcedencia { get; set; }
        public DateTime MCDS_FechaDictaminacion { get; set; }
        public string MCDS_UsuarioDominio { get; set; }
    }
}
