using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AjaxResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Mensaje { get; set; }
        public string Url { get; set; }

        public AjaxResult()
        {
            StatusCode = HttpStatusCode.OK;
        }

        public AjaxResult(Exception ex)
        {
            Mensaje = ex.Message;
            StatusCode = HttpStatusCode.InternalServerError;
        }
    }
}
