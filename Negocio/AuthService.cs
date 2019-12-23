using Entidades;
using Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Negocio
{
    public class AuthService : ServiceBase
    {
        public AuthService(ModelStateDictionary modelState) : base(modelState) { }

        public Usuario Login(HomeIndexViewModel viewModel)
        {
            Usuario _usuario = null;
            try
            {
                if (ModelState.IsValid)
                {
                    _usuario = UoW.Usuarios.Login(new Usuario
                    {
                        USU_Usuario = viewModel.USU_Usuario
                    });

                    if (_usuario != null)
                    {
                        if(_usuario.USU_Password != viewModel.USU_Password)
                        {
                            ModelState.AddModelError(string.Empty, "Las credenciales son incorrectas");
                            _usuario = null;
                        }
                            
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "No existe el usuario");
                    }
                }
                    
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return _usuario;
        }

        public ModulosHelper InitModulos(Usuario usuario)
        {
            var _modulos = new ModulosHelper();

            try
            {
                _modulos.Init(UoW.Usuarios.ObtenerModulos(usuario));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return _modulos;
        }


    }
}
