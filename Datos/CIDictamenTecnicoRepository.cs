using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CIDictamenTecnicoRepository : RepositoryBase<CIDictamenTecnico>
    {
        public CIDictamenTecnicoRepository(DatabaseContext context) : base(context)
        {
        }

        public override CIDictamenTecnico Alta(CIDictamenTecnico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CI_DictamenTecnico_IU", pGeneric.CIDT_IDDictamenTecnico, pGeneric.CIDT_IDCreditoInicial, pGeneric.CIDT_Procedencia
                , pGeneric.CIDT_MotivosProcedencia, pGeneric.CIDT_MontoSugerido, pGeneric.CIDT_FechaDictaminacion
                , pGeneric.CIDT_NoAsesorTecnico,  pGeneric.CIDT_UsuarioDominio);
        }

        public override void Baja(CIDictamenTecnico pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CIDictamenTecnico ObtenerEntidad(CIDictamenTecnico pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CI_DictamenTecnico_S", pGeneric.CIDT_IDCreditoInicial);
        }

        public override List<CIDictamenTecnico> ObtenerListado(CIDictamenTecnico pGeneric)
        {
            return ObtenerLista("SP_SIM_CI_DictamenTecnico_S", pGeneric.CIDT_FechaDictaminacion, pGeneric.CIDT_IDCreditoInicial, pGeneric.CIDT_IDDictamenTecnico
                , pGeneric.CIDT_MontoSugerido, pGeneric.CIDT_MotivosProcedencia, pGeneric.CIDT_NoAsesorTecnico, pGeneric.CIDT_Procedencia, pGeneric.CIDT_UsuarioDominio);
        }
    }
}
