using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Negocio
{
    public class RoleProviderBase : RoleProvider
    {
        public const string FORMATO_MODULO_PERMISO = "{0}:{1}";

        public static string GetRoleFormat(EnumModulo modulo, EnumModuloPermiso permiso)
        {
            return string.Format(FORMATO_MODULO_PERMISO, (int)modulo, (int)permiso);
        }

        public override string[] GetRolesForUser(string username)
        {
            var _roles = new UnitOfWork().Usuarios.ObtenerPermisos(new Usuario { USU_Id = username.ParseTo<int?>() });

            return _roles.ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var _roles = GetRolesForUser(username);

            return _roles.Contains(roleName);
        }

        #region NotImplemented
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
