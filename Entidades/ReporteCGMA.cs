using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class ReporteCGMA
    {

        public int CGMA_ID { get; set; }

        [Excel(Columna = "A", Encabezado = "ENVIADO A CGMA")]
        public string CGMA_Enviado { get; set; }

        [Excel(Columna = "B", Encabezado = "FOLIO CGMA")]
        public string CGMA_Folio { get; set; }

        [Excel(Columna = "C", Encabezado = "TRAMITE CGMA")]
        public int CGMA_Tramite { get; set; }

        [Excel(Columna = "D", Encabezado = "MODALIDAD CGMA")]
        public string CGMA_Modalidad { get; set; }

        [Excel(Columna = "E", Encabezado = "TIPO_SOLICITUD CGMA")]
        public int CGMA_TipoSolicitud { get; set; }

        [Excel(Columna = "F", Encabezado = "F_ENTRADA CGMA")]
        public DateTime CGMA_FechaEntrada { get; set; }

        [Excel(Columna = "G", Encabezado = "ATENCIÓN CGMA")]
        public int CGMA_Atencion { get; set; }

        [Excel(Columna = "H", Encabezado = "CALIFICACION CGMA")]
        public int CGMA_Calificacion { get; set; }

        [Excel(Columna = "I", Encabezado = "F_FINAL CGMA")]
        public DateTime CGMA_FechaFinal { get; set; }

        [Excel(Columna = "J", Encabezado = "ENTE CGMA")]
        public int CGMA_Ente { get; set; }

        [Excel(Columna = "K", Encabezado = "UNIDAD CGMA")]
        public string CGMA_Unidad { get; set; }

        [Excel(Columna = "L", Encabezado = "ACC CGMA")]
        public string CGMA_AAC { get; set; }

        [Excel(Columna = "M", Encabezado = "ENCARGADO CGMA")]
        public string CGMA_Encargado { get; set; }

        [Excel(Columna = "N", Encabezado = "PRIORITARIO CGMA")]
        public int CGMA_Prioritario { get; set; }

        [Excel(Columna = "O", Encabezado = "SEXO CGMA")]
        public int CGMA_Sexo { get; set; }

        [Excel(Columna = "P", Encabezado = "PERSONALIDAD CGMA")]
        public int CGMA_Personalidad { get; set; }

        [Excel(Columna = "Q", Encabezado = "ALCALDÍA CGMA")]
        public int CGMA_Delegacion { get; set; }

        [Excel(Columna = "R", Encabezado = "VULNERABLE CGMA")]
        public int CGMA_Vulnerable { get; set; }

        [Excel(Columna = "S", Encabezado = "CONS. ENTREGA CMV")]
        public string CGMA_ConsEntregaCMV { get; set; }

        [Excel(Columna = "T", Encabezado = "CLAVE TRAMITE CGMA")]
        public string CGMA_ClaveTramite { get; set; }

        [Excel(Columna = "U", Encabezado = "FOLIO SOLICITUD NO.")]
        public string CGMA_FolioSolicitud { get; set; }

        [Excel(Columna = "V", Encabezado = "NOMBRE COMPLETO CIUDADANO CGMA")]
        public string CGMA_NombreCiudadano { get; set; }

        [Excel(Columna = "W", Encabezado = "CALIFICACION CGMA")]
        public string CGMA_CalificacionFinal { get; set; }

    }
}
