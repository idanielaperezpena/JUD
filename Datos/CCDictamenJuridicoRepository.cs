using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class CCDictamenJuridicoRepository : RepositoryBase<CCDictamenJuridico>
    {
        public CCDictamenJuridicoRepository(DatabaseContext context) : base(context)
        {
        }

        public override CCDictamenJuridico Alta(CCDictamenJuridico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CC_DictamenJuridico_IU", pGeneric.CCDJ_Anuencia, pGeneric.CCDJ_DatosLibro, pGeneric.CCDJ_FechaDictaminacion, pGeneric.CCDJ_FolioDocumento
                , pGeneric.CCDJ_IDCreditoComplementario, pGeneric.CCDJ_IDDictamenJuridico, pGeneric.CCDJ_IDPropiedad, pGeneric.CCDJ_MotivosProcedencia, pGeneric.CCDJ_NoDocumentoPropiedad
                , pGeneric.CCDJ_Observaciones, pGeneric.CCDJ_Posesion, pGeneric.CCDJ_Procedencia, pGeneric.CCDJ_SuperficieLote, pGeneric.CCDJ_UsuarioDominio);
        }

        public override void Baja(CCDictamenJuridico pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CCDictamenJuridico ObtenerEntidad(CCDictamenJuridico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CC_DictamenJuridico_S", pGeneric.CCDJ_IDDictamenJuridico);
        }

        public override List<CCDictamenJuridico> ObtenerListado(CCDictamenJuridico pGeneric)
        {
            return ObtenerLista("SP_SIM_CC_DictamenJuridico_S", pGeneric.CCDJ_Anuencia, pGeneric.CCDJ_DatosLibro, pGeneric.CCDJ_FechaDictaminacion, pGeneric.CCDJ_FolioDocumento
                , pGeneric.CCDJ_IDCreditoComplementario, pGeneric.CCDJ_IDDictamenJuridico, pGeneric.CCDJ_IDPropiedad, pGeneric.CCDJ_MotivosProcedencia, pGeneric.CCDJ_NoDocumentoPropiedad
                , pGeneric.CCDJ_Observaciones, pGeneric.CCDJ_Posesion, pGeneric.CCDJ_Procedencia, pGeneric.CCDJ_SuperficieLote, pGeneric.CCDJ_UsuarioDominio);
        }
    }
}
