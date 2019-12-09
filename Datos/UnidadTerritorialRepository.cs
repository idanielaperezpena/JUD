using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UnidadTerritorialRepository : RepositoryBase<UnidadTerritorial>
    {
        public UnidadTerritorialRepository(DatabaseContext context) : base(context) { }

        public override UnidadTerritorial Alta(UnidadTerritorial pGeneric)
        {
            throw new NotImplementedException();
        }

        public override void Baja(UnidadTerritorial pGeneric)
        {
            throw new NotImplementedException();
        }

        public override UnidadTerritorial ObtenerEntidad(UnidadTerritorial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Cat_SN_UnidadTerritorial_S", pGeneric.ID);
        }

        public UnidadTerritorial ObtenerEntidadClave(UnidadTerritorial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Cat_SN_UnidadTerritorial_SC", pGeneric.Clave);
        }

        public override List<UnidadTerritorial> ObtenerListado(UnidadTerritorial pGeneric)
        {
            return ObtenerLista("SP_SIM_Cat_SN_UnidadTerritorial_S", pGeneric.ID);
        }
    }
}
