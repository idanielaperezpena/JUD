using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EnumTipoMenu
    {
        NoDefinido = 0,
        Lateral = 1,
        Administrador = 2
    }

    public enum EnumModulo
    {
        NoDefinido = 0,
        Exception = 1,
	    CreditoInicial = 2,
	    CreidtoComplementario = 3,
	    CreditoSustentabilidad = 4,
	    ModificacionesCredito = 5,
	    Catalogos  = 6,
	    ReporteCGMA = 7,
	    Ciudadanos   = 9,
	    MenuPrincipal  = 10,
	    DictamenSocial  = 11,
	    DictamenTecnico  = 14,
	    DictamenJuridico  = 15,
	    DictamenFinanciero  = 16
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
