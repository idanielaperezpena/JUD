using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ParejaRepository : RepositoryBase<Pareja>
    {
        public ParejaRepository(DatabaseContext context) : base(context)
        {
        }

        public override Pareja Alta(Pareja pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Pareja_IU"
                , pGeneric.PAR_IDPareja, pGeneric.PAR_IDCiudadano, pGeneric.PAR_Nombre
                , pGeneric.PAR_ApellidoPaterno, pGeneric.PAR_ApellidoMaterno
                , pGeneric.PAR_IDGenero, pGeneric.PAR_IDEstado, pGeneric.PAR_FechaNacimiento
                , pGeneric.PAR_IDRegimen);
        }

        public override void Baja(Pareja pGeneric)
        {
            throw new NotImplementedException();
        }

        public override Pareja ObtenerEntidad(Pareja pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Pareja_S", pGeneric.PAR_IDCiudadano);
        }

        public override List<Pareja> ObtenerListado(Pareja pGeneric)
        {
            throw new NotImplementedException();
        }
    }
}
