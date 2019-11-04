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
        public int CIU_TiempoResidencia { get; set; }
        public string CIU_TelParticular { get; set; }
        public string CIU_TelRecados { get; set; }
        public string CIU_TelTrabajo { get; set; }
        public string CIU_TelCelular { get; set; }
        public int CIU_IDEstadoCivil { get; set; }
        public int CIU_IDOrganizacionCivilFamilia { get; set; }
        public int CIU_IDGradoEstudios { get; set; }
        public int CIU_IDGrupoEtnico { get; set; }
        public string CIU_NumeroIdentificacion { get; set; }
        public int CIU_IDEnfermedadCronica { get; set; }
        public string CIU_EnfermedadCronicaOtro { get; set; }
        public int CIU_IDDiscapacidad { get; set; }
        public string CIU_DiscapacidadOtro { get; set; }
        public int CIU_IDGruposPrioritarios { get; set; }
        public string CIU_Proposito { get; set; }
        public bool CIU_CreditosOtorgados { get; set; }
        public double CIU_IngresoFamiliar { get; set; }
        public int CIU_IDEstructuraFamiliar { get; set; }
        public int CIU_IDOcupacion { get; set; }
        public string CIU_NombreTrabajo { get; set; }
        public int? CIU_IDDomicilioTrabajo { get; set; }    
        public double CIU_CapacidadPago { get; set; }
        public string CIU_CorreoElectronico { get; set; }
    }
}
