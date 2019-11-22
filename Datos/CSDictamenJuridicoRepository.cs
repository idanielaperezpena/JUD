using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CSDictamenJuridicoRepository : RepositoryBase<CSDictamenJuridico>
    {
        public CSDictamenJuridicoRepository(DatabaseContext context) : base(context)
        {
        }

        public override CSDictamenJuridico Alta(CSDictamenJuridico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CS_DictamenJuridico_IU"
                , pGeneric.CSDJ_IDDictamenJuridico, pGeneric.CSDJ_IDCreditoSustentabilidad, pGeneric.CSDJ_IDPropiedad
                , pGeneric.CSDJ_IDPosesion, pGeneric.CSDJ_NoDocumentoPropiedad, pGeneric.CSDJ_FechaDocumento, pGeneric.CSDJ_Anuencia
                , pGeneric.CSDJ_SuperficieLote, pGeneric.CSDJ_DatosLibro, pGeneric.CSDJ_FolioDocumento, pGeneric.CSDJ_Observaciones
                , pGeneric.CSDJ_Procedencia, pGeneric.CSDJ_MotivosProcedencia, pGeneric.CSDJ_FechaDictaminacion, pGeneric.CSDJ_UsuarioDominio);
        }

        public override void Baja(CSDictamenJuridico pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CSDictamenJuridico ObtenerEntidad(CSDictamenJuridico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CS_DictamenJuridico_S", pGeneric.CSDJ_IDCreditoSustentabilidad);
        }

        public override List<CSDictamenJuridico> ObtenerListado(CSDictamenJuridico pGeneric)
        {
            return ObtenerLista("SP_SIM_CS_DictamenJuridico_S", pGeneric.CSDJ_IDCreditoSustentabilidad);
        }
    }
}
