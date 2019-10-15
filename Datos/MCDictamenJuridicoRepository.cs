using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class MCDictamenJuridicoRepository : RepositoryBase<MCDictamenJuridico>
    {
        public MCDictamenJuridicoRepository(DatabaseContext context) : base(context)
        {
        }

        public override MCDictamenJuridico Alta(MCDictamenJuridico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_MC_DictamenJuridico_IU", pGeneric.MCDJ_Anuencia, pGeneric.MCDJ_DatosLibro, pGeneric.MCDJ_FechaDictaminacion, pGeneric.MCDJ_FolioDocumento
                , pGeneric.MCDJ_IDModificacionesCredito, pGeneric.MCDJ_IDDictamenJuridico, pGeneric.MCDJ_IDPropiedad, pGeneric.MCDJ_MotivosProcedencia, pGeneric.MCDJ_NoDocumentoPropiedad
                , pGeneric.MCDJ_Observaciones, pGeneric.MCDJ_Posesion, pGeneric.MCDJ_Procedencia, pGeneric.MCDJ_SuperficieLote, pGeneric.MCDJ_UsuarioDominio);
        }

        public override void Baja(MCDictamenJuridico pGeneric)
        {
            throw new NotImplementedException();
        }

        public override MCDictamenJuridico ObtenerEntidad(MCDictamenJuridico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_MC_DictamenJuridico_S", pGeneric.MCDJ_IDDictamenJuridico);
        }

        public override List<MCDictamenJuridico> ObtenerListado(MCDictamenJuridico pGeneric)
        {
            return ObtenerLista("SP_SIM_MC_DictamenJuridico_S", pGeneric.MCDJ_Anuencia, pGeneric.MCDJ_DatosLibro, pGeneric.MCDJ_FechaDictaminacion, pGeneric.MCDJ_FolioDocumento
                , pGeneric.MCDJ_IDModificacionesCredito, pGeneric.MCDJ_IDDictamenJuridico, pGeneric.MCDJ_IDPropiedad, pGeneric.MCDJ_MotivosProcedencia, pGeneric.MCDJ_NoDocumentoPropiedad
                , pGeneric.MCDJ_Observaciones, pGeneric.MCDJ_Posesion, pGeneric.MCDJ_Procedencia, pGeneric.MCDJ_SuperficieLote, pGeneric.MCDJ_UsuarioDominio);
        }
    }
}
