using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciudadano
    {
        public int? CIU_IDCiudadano { get; set; }
        public string CIU_CURP { get; set; }
        public string CIU_Nombre { get; set; }
        public string CIU_ApellidoPaterno { get; set; }
        public string CIU_ApellidoMaterno { get; set; }
        public int CIU_IDGenero { get; set; }
        public DateTime CIU_FechaNacimiento { get; set; }
        public int CIU_IDEstado { get; set; }
        public int? CIU_IDDomicilio { get; set; }
        public int CIU_TiempoResidencia { get; set; }
        public string CIU_TelParticular { get; set; }
        public string CIU_TelRecados { get; set; }
        public string CIU_TelTrabajo { get; set; }
        public string CIU_TelCelular { get; set; }
        public int CIU_IDEstadoCivil { get; set; }
        public int CIU_IDGradoEstudios { get; set; }
        public int CIU_IDgrupoEtnico { get; set; }
        public int CIU_IDRegimen { get; set; }
        public int? CIU_IDPareja { get; set; }
        public string CIU_Proposito { get; set; }
        public bool CIU_CreditosOtorgados { get; set; }
        public float CIU_IngresoFamiliar { get; set; }
        public int CIU_IDEstructuraFamiliar { get; set; }
        public int? CIU_IDSeguridadSocial { get; set; }
        public int CIU_IDProfesion { get; set; }
        public string CIU_NombreTrabajo { get; set; }
        public int? CIU_IDDomicilioTrabajo { get; set; }    
        public float CIU_CapacidadPAgo { get; set; }
        public string CIU_CorreoElectronico { get; set; }
    }
}
