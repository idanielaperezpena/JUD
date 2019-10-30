using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class SeccionElectoralRepository : RepositoryBase<SeccionElectoral>
    {
        public SeccionElectoralRepository(DatabaseContext context) : base(context) { }

        public override SeccionElectoral Alta(SeccionElectoral pGeneric)
        {
            throw new NotImplementedException();
        }

        public override void Baja(SeccionElectoral pGeneric)
        {
            throw new NotImplementedException();
        }

        public override SeccionElectoral ObtenerEntidad(SeccionElectoral pGeneric)
        {
            throw new NotImplementedException();
        }

        public override List<SeccionElectoral> ObtenerListado(SeccionElectoral pGeneric)
        {
            return ObtenerLista("SP_SIM_CAT_03_SeccionElectoral_S", pGeneric.ID);
        }
    }
}
