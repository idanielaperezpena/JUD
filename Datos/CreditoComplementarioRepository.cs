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
            return ObtenerPrimero("SP_SIM_CreditoComplementario_S", pGeneric.CC_FechaCaptura, pGeneric.CC_FechaSolicitud, pGeneric.CC_FolioSolicitud, pGeneric.CC_IDCreditoComplementario
                , pGeneric.CC_IDCreditoInicial, pGeneric.CC_IDMejoramiento, pGeneric.CC_Ingreso, pGeneric.CC_NoSesionComite);
        }

        public override void Baja(CreditoComplementario pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CreditoComplementario ObtenerEntidad(CreditoComplementario pGeneric)
        {
            CreditoComplementario _entidad;

            using (var reader = ObtenerDataReader("SP_SIM_CreditoComplementario_S", pGeneric.CC_IDCreditoComplementario))
            {
                _entidad = ObtenerPrimero(reader);
              
            }

            return _entidad;
        }

        public override List<CreditoComplementario> ObtenerListado(CreditoComplementario pGeneric)
        {
            return ObtenerLista("SP_SIM_CreditoComplementario_S", pGeneric.CC_IDCreditoComplementario);
        }
    }
}
