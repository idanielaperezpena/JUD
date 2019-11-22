using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CSDictamenSocialRepository : RepositoryBase<CSDictamenSocial>
    {
        public CSDictamenSocialRepository(DatabaseContext context) : base(context)
        {
        }

        public override CSDictamenSocial Alta(CSDictamenSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CS_DictamenSocial_IU"
                , pGeneric.CSDS_IDDictamenSocial, pGeneric.CSDS_IDCreditoSustentabilidad, pGeneric.CSDS_IDTipoPredio
                , pGeneric.CSDS_IDCaracteristicasPredio, pGeneric.CSDS_NoFamiliasLote, pGeneric.CSDS_NoFamiliasVivienda, pGeneric.CSDS_NoViviendasLote
                , pGeneric.CSDS_NoPersonasVivienda, pGeneric.CSDS_IDServicioAgua, pGeneric.CSDS_IDServicioDrenaje, pGeneric.CSDS_IDServicioElectrico
                , pGeneric.CSDS_Desdoblamiento, pGeneric.CSDS_BanoCompartido, pGeneric.CSDS_CocinaCompartido, pGeneric.CSDS_IDHacinamiento
                , pGeneric.CSDS_IDInsalubridad, pGeneric.CSDS_OtroInsalubridad, pGeneric.CSDS_FechaVisita, pGeneric.CSDS_Observaciones, pGeneric.CSDS_NoEmpleadoVisita
                , pGeneric.CSDS_Procedencia, pGeneric.CSDS_IDVulnerabilidad, pGeneric.CSDS_MotivosProcedencia, pGeneric.CSDS_FechaDictaminacion, pGeneric.CSDS_UsuarioDominio);
        }

        public override void Baja(CSDictamenSocial pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CSDictamenSocial ObtenerEntidad(CSDictamenSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CS_DictamenSocial_S", pGeneric.CSDS_IDCreditoSustentabilidad);
        }

        public override List<CSDictamenSocial> ObtenerListado(CSDictamenSocial pGeneric)
        {
            return ObtenerLista("SP_SIM_CS_DictamenSocial_S",pGeneric.CSDS_IDCreditoSustentabilidad);
        }
    }
}
