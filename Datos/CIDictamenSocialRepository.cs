using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CIDictamenSocialRepository : RepositoryBase<CIDictamenSocial>
    {
        public CIDictamenSocialRepository(DatabaseContext context) : base(context)
        {
        }

        public override CIDictamenSocial Alta(CIDictamenSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CI_DictamenSocial_IU", pGeneric.CIDS_IDDictamenSocial, pGeneric.CIDS_IDCreditoInicial, pGeneric.CIDS_IDTipoPredio
                , pGeneric.CIDS_IDCaracteristicasPredio, pGeneric.CIDS_NoFamiliasLote, pGeneric.CIDS_NoFamiliasVivienda, pGeneric.CIDS_NoViviendasLote
                , pGeneric.CIDS_NoPersonasVivienda, pGeneric.CIDS_IDServicioAgua, pGeneric.CIDS_IDServicioDrenaje, pGeneric.CIDS_IDServicioElectrico
                , pGeneric.CIDS_Desdoblamiento, pGeneric.CIDS_BanoCompartido, pGeneric.CIDS_CocinaCompartido, pGeneric.CIDS_IDHacinamiento
                , pGeneric.CIDS_IDInsalubridad, pGeneric.CIDS_OtroInsalubridad, pGeneric.CIDS_FechaVisita, pGeneric.CIDS_Observaciones, pGeneric.CIDS_NoEmpleadoVisita
                , pGeneric.CIDS_Procedencia, pGeneric.CIDS_IDVulnerabilidad, pGeneric.CIDS_MotivosProcedencia, pGeneric.CIDS_FechaDictaminacion, pGeneric.CIDS_UsuarioDominio);
        }

        public override void Baja(CIDictamenSocial pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CIDictamenSocial ObtenerEntidad(CIDictamenSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CI_DictamenSocial_S", pGeneric.CIDS_IDCreditoInicial);
        }

        public override List<CIDictamenSocial> ObtenerListado(CIDictamenSocial pGeneric)
        {
            return ObtenerLista("SP_SIM_CI_DictamenSocial_S", pGeneric.CIDS_IDCreditoInicial);
        }
    }
}
