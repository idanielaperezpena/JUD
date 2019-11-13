using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MCDictamenTecnicoRepository : RepositoryBase<MCDictamenTecnico>
    {
        public MCDictamenTecnicoRepository(DatabaseContext context) : base(context)
        {
        }

        public override MCDictamenTecnico Alta(MCDictamenTecnico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_MC_DictamenTecnico_IU", pGeneric.MCDT_FechaDictaminacion, pGeneric.MCDT_IDModificacionesCredito, pGeneric.MCDT_IDDictamenTecnico
                , pGeneric.MCDT_MontoSugerido, pGeneric.MCDT_MotivosProcedencia, pGeneric.MCDT_NoAsesorTecnico, pGeneric.MCDT_Procedencia, pGeneric.MCDT_UsuarioDominio);
        }

        public override void Baja(MCDictamenTecnico pGeneric)
        {
            throw new NotImplementedException();
        }

        public override MCDictamenTecnico ObtenerEntidad(MCDictamenTecnico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_MC_DictamenTecnico_S", pGeneric.MCDT_IDDictamenTecnico);
        }

        public override List<MCDictamenTecnico> ObtenerListado(MCDictamenTecnico pGeneric)
        {
            return ObtenerLista("SP_SIM_MC_DictamenTecnico_S", pGeneric.MCDT_FechaDictaminacion, pGeneric.MCDT_IDModificacionesCredito, pGeneric.MCDT_IDDictamenTecnico
                , pGeneric.MCDT_MontoSugerido, pGeneric.MCDT_MotivosProcedencia, pGeneric.MCDT_NoAsesorTecnico, pGeneric.MCDT_Procedencia, pGeneric.MCDT_UsuarioDominio);
        }
    }
}
