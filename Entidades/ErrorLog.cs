using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class ErrorLog
    {
        public int? ERR_Id { get; set; }
        public int? USU_Id { get; set; }
        [Display(Name = "Folio")]
        public string ERR_Folio { get; set; }
        [Display(Name = "Session ID")]
        public string ERR_SessionID { get; set; }
        [Display(Name = "IP")]
        public string ERR_RemoteAddr { get; set; }
        [Display(Name = "Http String")]
        public string ERR_AllHttp { get; set; }
        [Display(Name = "Navegador")]
        public string ERR_UserAgent { get; set; }
        [Display(Name = "Http Method")]
        public string ERR_RequestMethod { get; set; }
        [Display(Name = "Url")]
        public string ERR_Url { get; set; }
        [Display(Name = "QueryString")]
        public string ERR_Query { get; set; }
        [Display(Name = "Form")]
        public string ERR_Form { get; set; }
        [Display(Name = "Tipo")]
        public string ERR_Type { get; set; }
        [Display(Name = "Mensaje")]
        public string ERR_Message { get; set; }
        [Display(Name = "Target")]
        public string ERR_TargetSite { get; set; }
        [Display(Name = "StackTrace")]
        public string ERR_StackTrace { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? ERR_Fecha { get; set; }


        public DateTime? ERR_FechaInicio { get; set; }
        public DateTime? ERR_FechaFin { get; set; }

        [Display(Name = "Usuario")]
        public string USU_Nombre { get; set; }
        public Exception Ex { get; set; }

        public string SoporteEmail { get; set; }
        public string SoporteAsunto { get; set; }
        public string SoporteTitulo { get; set; }
        public string MensajeView { get; set; }
    }
}
