using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class CreditoSustentabilidadRepositoy : RepositoryBase<CreditoSustentabilidad>
    {
        public CreditoSustentabilidadRepositoy(DatabaseContext context) : base(context)
        {
        }

        public override CreditoSustentabilidad Alta(CreditoSustentabilidad pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CreditoSustentabilidad_IU", pGeneric.CS_FechaCaptura, pGeneric.CS_FechaSolicitud, pGeneric.CS_FolioSolicitud
                , pGeneric.CS_IDCreditoInicial, pGeneric.CS_IDCreditoSustentabilidad);
        }

        public override void Baja(CreditoSustentabilidad pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CreditoSustentabilidad ObtenerEntidad(CreditoSustentabilidad pGeneric)
        {
            CreditoSustentabilidad _entidad;
            using (var reader = ObtenerDataReader("SP_SIM_CreditoSustentabilidad_S", pGeneric.CS_IDCreditoSustentabilidad))
            {
                _entidad = ObtenerPrimero(reader);
                reader.NextResult();
            }

            return _entidad;
        }

        public override List<CreditoSustentabilidad> ObtenerListado(CreditoSustentabilidad pGeneric)
        {
            return ObtenerLista("SP_SIM_CreditoSustentabilidad_S", pGeneric.CS_FechaCaptura, pGeneric.CS_FechaSolicitud, pGeneric.CS_FolioSolicitud
                , pGeneric.CS_IDCreditoInicial, pGeneric.CS_IDCreditoSustentabilidad);
        }
    }
}
