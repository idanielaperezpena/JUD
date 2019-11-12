using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class PrincipalRepository : RepositoryBase<Principal>
    {
        public PrincipalRepository(DatabaseContext context) : base(context)
        {
        }

        public override Principal Alta(Principal pGeneric)
        {
            throw new NotImplementedException();
        }

        public override void Baja(Principal pGeneric)
        {
            throw new NotImplementedException();
        }

        public override Principal ObtenerEntidad(Principal pGeneric)
        {
            throw new NotImplementedException();
        }

        public override List<Principal> ObtenerListado(Principal pGeneric)
        {
            throw new NotImplementedException();
        }

        public Principal ObtenerDatosPrincipal()
        {
            throw new NotImplementedException();
        }
    }
}
