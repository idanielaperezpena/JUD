using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class MCDictamenFinancieroRepository : RepositoryBase<MCDictamenFinanciero>
    {
        public MCDictamenFinancieroRepository(DatabaseContext context) : base(context)
        {
        }

        public override MCDictamenFinanciero Alta(MCDictamenFinanciero pGeneric)
        {
            return ObtenerPrimero("SP_SIM_MC_DictamenFinanciero_IU", pGeneric.MCDF_FechaDictaminacion, pGeneric.MCDF_IDModificacionesCredito, pGeneric.MCDF_IDDictamenFinanciero
                , pGeneric.MCDF_IDUMA, pGeneric.MCDF_MotivosProcedencia, pGeneric.MCDF_NoMesesAmortizacion, pGeneric.MCDF_NoMontoCreditoUMA, pGeneric.MCDF_NoPagoUMA
                , pGeneric.MCDF_Procedencia, pGeneric.MCDF_UsuarioDominio);
        }

        public override void Baja(MCDictamenFinanciero pGeneric)
        {
            throw new NotImplementedException();
        }

        public override MCDictamenFinanciero ObtenerEntidad(MCDictamenFinanciero pGeneric)
        {
          return  ObtenerPrimero("SP_SIM_MC_DictamenFinanciero_S", pGeneric.MCDF_IDDictamenFinanciero);
        }

        public override List<MCDictamenFinanciero> ObtenerListado(MCDictamenFinanciero pGeneric)
        {
            return ObtenerLista("SP_SIM_MC_DictamenFinanciero_S", pGeneric.MCDF_FechaDictaminacion, pGeneric.MCDF_IDModificacionesCredito, pGeneric.MCDF_IDDictamenFinanciero
                , pGeneric.MCDF_IDUMA, pGeneric.MCDF_MotivosProcedencia, pGeneric.MCDF_NoMesesAmortizacion, pGeneric.MCDF_NoMontoCreditoUMA, pGeneric.MCDF_NoPagoUMA
                , pGeneric.MCDF_Procedencia, pGeneric.MCDF_UsuarioDominio);
        }
    }
}
