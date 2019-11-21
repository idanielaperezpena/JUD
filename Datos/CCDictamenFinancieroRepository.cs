using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CCDictamenFinancieroRepository : RepositoryBase<CCDictamenFinanciero>
    {
        public CCDictamenFinancieroRepository(DatabaseContext context) : base(context)
        {
        }

        public override CCDictamenFinanciero Alta(CCDictamenFinanciero pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CC_DictamenFinanciero_IU"
                , pGeneric.CCDF_IDDictamenFinanciero, pGeneric.CCDF_IDCreditoComplementario
                , pGeneric.CCDF_Procedencia, pGeneric.CCDF_MotivosProcedencia, pGeneric.CCDF_IDUMA, pGeneric.CCDF_NoMontoCreditoUMA
                , pGeneric.CCDF_NoMesesAmortizacion, pGeneric.CCDF_NoPagoUMA, pGeneric.CCDF_FechaDictaminacion, pGeneric.CCDF_UsuarioDominio);
        }

        public override void Baja(CCDictamenFinanciero pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CCDictamenFinanciero ObtenerEntidad(CCDictamenFinanciero pGeneric)
        {
          return  ObtenerPrimero("SP_SIM_CC_DictamenFinanciero_S", pGeneric.CCDF_IDCreditoComplementario);
        }

        public override List<CCDictamenFinanciero> ObtenerListado(CCDictamenFinanciero pGeneric)
        {
            return ObtenerLista("SP_SIM_CC_DictamenFinanciero_S", pGeneric.CCDF_FechaDictaminacion);
        }
    }
}
