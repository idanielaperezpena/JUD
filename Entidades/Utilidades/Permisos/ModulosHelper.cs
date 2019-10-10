using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ModulosHelper
    {
        /// <summary>
        /// Listado de Modulos habilitados para el usuario
        /// </summary>
        private List<Modulo> _modulos;
        /// <summary>
        /// Listado de modulos al mismo nivel jerárquico
        /// </summary>
        private IEnumerable<Modulo> _itModulos;

        /// <summary>
        /// Obtiene la estructura del Modulo especificado
        /// </summary>
        /// <param name="modulo">Modulo solicitado</param>
        /// <returns>Objeto modulo con sus submodulos y acciones</returns>
        // Esta clase convertirla en privada
        public Modulo this[EnumModulo modulo]
        {
            get
            {
                if (_itModulos == null)
                    return new Modulo();

                return _itModulos.FirstOrDefault(mdl => mdl.TipoModulo == modulo && mdl.Permisos.Count > 0) ?? new Modulo();
            }
        }

        /// <summary>
        /// Obtiene el listado de modulos de acuerdo al lugar donde se generarán
        /// </summary>
        /// <param name="TipoMenu">TipoMenu de Menú, Lateral o Panel de Usuario</param>
        /// <returns>Listado de objetos modulo con sus submodulos y acciones</returns>
        public List<Modulo> this[EnumTipoMenu TipoMenu]
        {
            get
            {
                if (_modulos == null)
                    return new List<Modulo>();

                return _modulos.Where(mdl => mdl.TipoMenu == TipoMenu).ToList();
            }
        }

        public void Init(List<Modulo> modulos)
        {
            _itModulos = modulos;
            _modulos = MapearModulo(modulos);
        }

        /// <summary>
        /// Carga los submodulos y las acciones (permisos) que se tienen configurados
        /// </summary>
        /// <param name="_permisos">Estructura completa de Modulos y Permisos</param>
        /// <param name="MDL_Id">ID del modulo a cargar</param>
        /// <returns></returns>
        private List<Modulo> MapearModulo(List<Modulo> _permisos, int? MDL_Id = null)
        {
            List<Modulo> mdls = new List<Modulo>();

            foreach (var m in _permisos.Where(m => m.MDL_Parent == MDL_Id))
            {
                if (!mdls.Any(mdl => mdl.MDL_Id == m.MDL_Id))
                {
                    m.SubModulos = MapearModulo(_permisos, m.MDL_Id);
                    m.Permisos = _permisos.Where(md => md.MDL_Id == m.MDL_Id).Select(a => a.TipoPermiso).ToList();
                    mdls.Add(m);
                }
            }

            return mdls;
        }
    }
}
