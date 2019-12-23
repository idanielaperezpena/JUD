using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Datos
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository(DatabaseContext context) : base(context) { }

        public override Usuario Alta(Usuario pGeneric)
        {
            throw new NotImplementedException();
        }

        public override void Baja(Usuario pGeneric)
        {
            throw new NotImplementedException();
        }

        public override Usuario ObtenerEntidad(Usuario pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Usuarios_S", pGeneric.USU_Id);
        }

        public override List<Usuario> ObtenerListado(Usuario pGeneric)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(Usuario pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Usuarios_S_USU", pGeneric.USU_Usuario);
        }

        public List<string> ObtenerPermisos(Usuario pGeneric)
        {
            return ObtenerLista<string>("SP_SIM_CatUsuario_Permisos_S", pGeneric.USU_Id);
        }

        public List<Modulo> ObtenerModulos(Usuario pGeneric)
        {
            return ObtenerLista<Modulo>("SP_SIM_CatUsuario_Modulos_S", pGeneric.USU_Id);
        }
    }
}