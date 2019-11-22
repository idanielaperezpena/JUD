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
            return ObtenerPrimero("SP_SIM_CS_DictamenTecnico_IU"
                , pGeneric.CSDT_IDDictamenTecnico, pGeneric.CSDT_IDCreditoSustentabilidad, pGeneric.CSDT_Procedencia
                , pGeneric.CSDT_MotivosProcedencia, pGeneric.CSDT_MontoSugerido, pGeneric.CSDT_FechaDictaminacion
                , pGeneric.CSDT_NoAsesorTecnico, pGeneric.CSDT_UsuarioDominio);
        }

        public override void Baja(CSDictamenTecnico pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CSDictamenTecnico ObtenerEntidad(CSDictamenTecnico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CS_DictamenTecnico_S", pGeneric.CSDT_IDCreditoSustentabilidad);
        }

        public override List<CSDictamenTecnico> ObtenerListado(CSDictamenTecnico pGeneric)
        {
            return ObtenerLista("SP_SIM_CS_DictamenTecnico_S", pGeneric.CSDT_IDCreditoSustentabilidad);
        }
    }
}
