using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EnumNotificacionEmail
    {
        [Description("Plantilla.html")]
        Plantilla,
        [Description("Errores.html")]
        Errores
    }
}
