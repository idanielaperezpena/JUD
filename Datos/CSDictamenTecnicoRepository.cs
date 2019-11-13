using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CSDictamenTecnicoRepository : RepositoryBase<CSDictamenTecnico>
    {
        public CSDictamenTecnicoRepository(DatabaseContext context) : base(context)
        {
        }

        public override CSDictamenTecnico Alta(CSDictamenTecnico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CS_DictamenTecnico_IU", pGeneric.CSDT_FechaDictaminacion, pGeneric.CSDT_IDCreditoSustentabilidad, pGeneric.CSDT_IDDictamenTecnico
                , pGeneric.CSDT_MontoSugerido, pGeneric.CSDT_MotivosProcedencia, pGeneric.CSDT_NoAsesorTecnico, pGeneric.CSDT_Procedencia, pGeneric.CSDT_UsuarioDominio);
        }

        public override void Baja(CSDictamenTecnico pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CSDictamenTecnico ObtenerEntidad(CSDictamenTecnico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CS_DictamenTecnico_S", pGeneric.CSDT_IDDictamenTecnico);
        }

        public override List<CSDictamenTecnico> ObtenerListado(CSDictamenTecnico pGeneric)
        {
            return ObtenerLista("SP_SIM_CS_DictamenTecnico_S", pGeneric.CSDT_FechaDictaminacion, pGeneric.CSDT_IDCreditoSustentabilidad, pGeneric.CSDT_IDDictamenTecnico
                , pGeneric.CSDT_MontoSugerido, pGeneric.CSDT_MotivosProcedencia, pGeneric.CSDT_NoAsesorTecnico, pGeneric.CSDT_Procedencia, pGeneric.CSDT_UsuarioDominio);
        }
    }
}
