using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DeudorSolidario
    {
        public int? DEU_IDDeudorSolidario { get; set; }
        public int DEU_IDCiudadano { get; set; }
        public string DEU_CURP { get; set; }
        public string DEU_Nombre { get; set; }
        public string DEU_ApellidoPaterno { get; set; }
        public string DEU_ApellidoMaterno { get; set; }
        public int DEU_IDGenero { get; set; }
        public int? DEU_IDDomicilio { get; set; }
        public float DEU_Ingreso { get; set; }
        public float DEU_CapacidadPago { get; set; }
        public string DEU_Telefono { get; set; }
        public int DEU_IDEstadoCivil { get; set; }
        public int DEU_IDProfesion { get; set; }
        public string DEU_NombreTrabajo { get; set; }
        public int? DEU_IDDomicilioTrabajo { get; set; }
        public DateTime DEU_FechaSolicitud { get; set; }
    }
}
