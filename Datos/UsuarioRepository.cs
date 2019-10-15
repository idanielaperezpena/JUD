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
            throw new NotImplementedException();
        }

        public override List<Usuario> ObtenerListado(Usuario pGeneric)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(Usuario pGeneric)
        {
            //throw new NotImplementedException();
            return new Usuario { USU_Id =1 , USU_Usuario="jams", USU_Password = "1234" };
        }

        public List<string> ObtenerPermisos(Usuario pGeneric)
        {
            return ObtenerLista<string>("SP_CatUsuario_Permisos_S", pGeneric.USU_Id);
        }

        public List<Modulo> ObtenerModulos(Usuario pGeneric)
        {
            return ObtenerLista<Modulo>("SP_CatUsuario_Modulos_S", pGeneric.USU_Id);
        }
    }
}