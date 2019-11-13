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
            Principal _entidad;

            using (var reader = ObtenerDataReader("SP_NumeroDictamenes"))
            {
                _entidad = ObtenerPrimero(reader);

            }

            return _entidad;
        }

        public Principal ObetenerEstatusCI(CreditoInicial pGeneric)
        {
            Principal _entidad;

            using (var reader = ObtenerDataReader("SP_VerificarDictamen_CI", pGeneric.CI_IDCreditoInicial))
            {
                _entidad = ObtenerPrimero(reader);

            }

            return _entidad;
        }
    }
}
