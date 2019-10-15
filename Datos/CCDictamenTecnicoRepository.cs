using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class CCDictamenTecnicoRepository : RepositoryBase<CCDictamenTecnico>
    {
        public CCDictamenTecnicoRepository(DatabaseContext context) : base(context)
        {
        }

        public override CCDictamenTecnico Alta(CCDictamenTecnico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CC_DictamenTecnico_IU", pGeneric.CCDT_FechaDictaminacion, pGeneric.CCDT_IDCreditoComplementario, pGeneric.CCDT_IDDictamenTecnico
                , pGeneric.CCDT_MontoSugerido, pGeneric.CCDT_MotivosProcedencia, pGeneric.CCDT_NoAsesorTecnico, pGeneric.CCDT_Procedencia, pGeneric.CCDT_UsuarioDominio);
        }

        public override void Baja(CCDictamenTecnico pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CCDictamenTecnico ObtenerEntidad(CCDictamenTecnico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CC_DictamenTecnico_S", pGeneric.CCDT_IDDictamenTecnico);
        }

        public override List<CCDictamenTecnico> ObtenerListado(CCDictamenTecnico pGeneric)
        {
            return ObtenerLista("SP_SIM_CC_DictamenTecnico_S", pGeneric.CCDT_FechaDictaminacion, pGeneric.CCDT_IDCreditoComplementario, pGeneric.CCDT_IDDictamenTecnico
                , pGeneric.CCDT_MontoSugerido, pGeneric.CCDT_MotivosProcedencia, pGeneric.CCDT_NoAsesorTecnico, pGeneric.CCDT_Procedencia, pGeneric.CCDT_UsuarioDominio);
        }
    }
}
