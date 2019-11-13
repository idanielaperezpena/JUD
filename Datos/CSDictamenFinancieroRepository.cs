using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CSDictamenFinancieroRepository : RepositoryBase<CSDictamenFinanciero>
    {
        public CSDictamenFinancieroRepository(DatabaseContext context) : base(context)
        {
        }

        public override CSDictamenFinanciero Alta(CSDictamenFinanciero pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CS_DictamenFinanciero_IU", pGeneric.CSDF_FechaDictaminacion, pGeneric.CSDF_IDCreditoSustentabilidad, pGeneric.CSDF_IDDictamenFinanciero
                , pGeneric.CSDF_IDUMA, pGeneric.CSDF_MotivosProcedencia, pGeneric.CSDF_NoMesesAmortizacion, pGeneric.CSDF_NoMontoCreditoUMA, pGeneric.CSDF_NoPagoUMA
                , pGeneric.CSDF_Procedencia, pGeneric.CSDF_UsuarioDominio);
        }

        public override void Baja(CSDictamenFinanciero pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CSDictamenFinanciero ObtenerEntidad(CSDictamenFinanciero pGeneric)
        {
          return  ObtenerPrimero("SP_SIM_CS_DictamenFinanciero_S", pGeneric.CSDF_IDDictamenFinanciero);
        }

        public override List<CSDictamenFinanciero> ObtenerListado(CSDictamenFinanciero pGeneric)
        {
            return ObtenerLista("SP_SIM_CS_DictamenFinanciero_S", pGeneric.CSDF_FechaDictaminacion, pGeneric.CSDF_IDCreditoSustentabilidad, pGeneric.CSDF_IDDictamenFinanciero
                , pGeneric.CSDF_IDUMA, pGeneric.CSDF_MotivosProcedencia, pGeneric.CSDF_NoMesesAmortizacion, pGeneric.CSDF_NoMontoCreditoUMA, pGeneric.CSDF_NoPagoUMA
                , pGeneric.CSDF_Procedencia, pGeneric.CSDF_UsuarioDominio);
        }
    }
}
