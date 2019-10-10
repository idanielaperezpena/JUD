using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ErrorLogRepository : RepositoryBase<ErrorLog>
    {
        public ErrorLogRepository(DatabaseContext context) : base(context) { }

        public override ErrorLog Alta(ErrorLog pGeneric)
        {
            return ObtenerPrimero("SP_MVC_ErrorLog_I", pGeneric.USU_Id, pGeneric.ERR_SessionID, pGeneric.ERR_RemoteAddr, pGeneric.ERR_AllHttp, pGeneric.ERR_UserAgent, pGeneric.ERR_RequestMethod,
                pGeneric.ERR_Url, pGeneric.ERR_Query, pGeneric.ERR_Form, pGeneric.ERR_Type, pGeneric.ERR_Message, pGeneric.ERR_TargetSite, pGeneric.ERR_StackTrace);
        }

        public override void Baja(ErrorLog pGeneric)
        {
            throw new NotImplementedException();
        }

        public override ErrorLog ObtenerEntidad(ErrorLog pGeneric)
        {
            return ObtenerPrimero("SP_MVC_ErrorLog_S", pGeneric.ERR_Id);
        }

        public override List<ErrorLog> ObtenerListado(ErrorLog pGeneric)
        {
            return ObtenerLista("SP_MVC_ErrorLogListado_S", pGeneric.ERR_FechaInicio, pGeneric.ERR_FechaFin, pGeneric.ERR_Folio);
        }
    }
}
