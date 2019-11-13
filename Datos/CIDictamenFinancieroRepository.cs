using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CIDictamenFinancieroRepository : RepositoryBase<CIDictamenFinanciero>
    {
        public CIDictamenFinancieroRepository(DatabaseContext context) : base(context)
        {
        }

        public override CIDictamenFinanciero Alta(CIDictamenFinanciero pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CI_DictamenFinanciero_IU", pGeneric.CIDF_IDDictamenFinanciero, pGeneric.CIDF_IDCreditoInicial
                , pGeneric.CIDF_Procedencia, pGeneric.CIDF_MotivosProcedencia, pGeneric.CIDF_IDUMA, pGeneric.CIDF_NoMontoCreditoUMA
                , pGeneric.CIDF_NoMesesAmortizacion, pGeneric.CIDF_NoPagoUMA, pGeneric.CIDF_FechaDictaminacion, pGeneric.CIDF_UsuarioDominio);
        }

        public override void Baja(CIDictamenFinanciero pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CIDictamenFinanciero ObtenerEntidad(CIDictamenFinanciero pGeneric)
        {
          return  ObtenerPrimero("SP_SIM_CI_DictamenFinanciero_S", pGeneric.CIDF_IDCreditoInicial);
        }

        public override List<CIDictamenFinanciero> ObtenerListado(CIDictamenFinanciero pGeneric)
        {
            return ObtenerLista("SP_SIM_CI_DictamenFinanciero_S", pGeneric.CIDF_IDCreditoInicial);
        }
    }
}
