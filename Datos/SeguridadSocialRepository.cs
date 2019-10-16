using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class SeguridadSocialRepository : RepositoryBase<SeguridadSocial>
    {
        public SeguridadSocialRepository(DatabaseContext context) : base(context)
        {
        }

        public override SeguridadSocial Alta(SeguridadSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_SeguridadSocial_IU", pGeneric.SSO_Clave, pGeneric.SSO_IDCiudadano, pGeneric.SSO_IDSeguridadSocial
                , pGeneric.SSO_IDTipo);
        }

        public override void Baja(SeguridadSocial pGeneric)
        {
            throw new NotImplementedException();
        }

        public override SeguridadSocial ObtenerEntidad(SeguridadSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Seguridad_S", pGeneric.SSO_IDCiudadano);
        }

        public override List<SeguridadSocial> ObtenerListado(SeguridadSocial pGeneric)
        {
            return ObtenerLista("SP_SIM_SeguridadSocial_S", pGeneric.SSO_Clave, pGeneric.SSO_IDCiudadano, pGeneric.SSO_IDSeguridadSocial
                , pGeneric.SSO_IDTipo);
        }
    }
}
