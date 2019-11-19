using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CreditoComplementarioRepository : RepositoryBase<CreditoComplementario>
    {
        public CreditoComplementarioRepository(DatabaseContext context) : base(context)
        {
        }

        public override CreditoComplementario Alta(CreditoComplementario pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CreditoComplementario_IU", pGeneric.CC_IDCreditoComplementario, pGeneric.CC_IDCreditoInicial
                , pGeneric.CC_FolioSolicitud, pGeneric.CC_FechaCaptura, pGeneric.CC_FechaSolicitud, pGeneric.CC_NoSesionComite
                , pGeneric.CC_IDMejoramiento, pGeneric.CC_Ingreso);
        }

        public override void Baja(CreditoComplementario pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CreditoComplementario ObtenerEntidad(CreditoComplementario pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CreditoComplementario_S", pGeneric.CC_IDCreditoComplementario);
                                  
        }

        public override List<CreditoComplementario> ObtenerListado(CreditoComplementario pGeneric)
        {
            return ObtenerLista("SP_SIM_CreditoComplementario_S");
        }
    }
}
