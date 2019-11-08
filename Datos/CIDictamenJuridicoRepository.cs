using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class CIDictamenJuridicoRepository : RepositoryBase<CIDictamenJuridico>
    {
        public CIDictamenJuridicoRepository(DatabaseContext context) : base(context)
        {
        }

        public override CIDictamenJuridico Alta(CIDictamenJuridico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CI_DictamenJuridico_IU", pGeneric.CIDJ_IDDictamenJuridico, pGeneric.CIDJ_IDCreditoInicial, pGeneric.CIDJ_IDPropiedad
                , pGeneric.CIDJ_IDPosesion, pGeneric.CIDJ_NoDocumentoPropiedad, pGeneric.CIDJ_FechaDocumento, pGeneric.CIDJ_Anuencia
                , pGeneric.CIDJ_SuperficieLote, pGeneric.CIDJ_DatosLibro, pGeneric.CIDJ_FolioDocumento, pGeneric.CIDJ_Observaciones
                , pGeneric.CIDJ_Procedencia, pGeneric.CIDJ_MotivosProcedencia, pGeneric.CIDJ_FechaDictaminacion, pGeneric.CIDJ_UsuarioDominio);
        }

        public override void Baja(CIDictamenJuridico pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CIDictamenJuridico ObtenerEntidad(CIDictamenJuridico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CI_DictamenJuridico_S", pGeneric.CIDJ_IDCreditoInicial);
        }

        public override List<CIDictamenJuridico> ObtenerListado(CIDictamenJuridico pGeneric)
        {
            return ObtenerLista("SP_SIM_CI_DictamenJuridico_S", pGeneric.CIDJ_IDCreditoInicial);
        }
    }
}
