using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EnumTipoMenu
    {
        NoDefinido = 0
    }

    public enum EnumModulo
    {
        NoDefinido = 0,
        Exception = 1
    }

    public enum EnumModuloPermiso
    {
        NoDefinido = 0,
        Consulta = 1,
        Alta = 2,
        Edicion = 3,
        Baja = 4
    }
}
