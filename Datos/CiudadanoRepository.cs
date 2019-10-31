using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CiudadanoRepository : RepositoryBase<Ciudadano>
    {
        public CiudadanoRepository(DatabaseContext context) : base(context)
        {
        }

        public override Ciudadano Alta(Ciudadano pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Ciudadano_IU", pGeneric.CIU_IDCiudadano, pGeneric.CIU_CURP, pGeneric.CIU_Nombre, pGeneric.CIU_ApellidoPaterno
                , pGeneric.CIU_ApellidoMaterno, pGeneric.CIU_IDGenero, pGeneric.CIU_FechaNacimiento, pGeneric.CIU_IDEstado, pGeneric.CIU_IDDomicilio
                , pGeneric.CIU_TiempoResidencia, pGeneric.CIU_TelParticular, pGeneric.CIU_TelRecados, pGeneric.CIU_TelTrabajo, pGeneric.CIU_TelCelular, pGeneric.CIU_IDEstadoCivil
                , pGeneric.CIU_IDOrganizacionCivilFamilia, pGeneric.CIU_IDGradoEstudios, pGeneric.CIU_IDGrupoEtnico, pGeneric.CIU_NumeroIdentificacion
                , pGeneric.CIU_IDEnfermedadCronica, pGeneric.CIU_EnfermedadCronicaOtro, pGeneric.CIU_IDDiscapacidad, pGeneric.CIU_DiscapacidadOtro, pGeneric.CIU_IDGruposPrioritarios, pGeneric.CIU_Proposito
                , pGeneric.CIU_CreditosOtorgados, pGeneric.CIU_IngresoFamiliar, pGeneric.CIU_IDEstructuraFamiliar, pGeneric.CIU_IDOcupacion, pGeneric.CIU_NombreTrabajo
                , pGeneric.CIU_IDDomicilioTrabajo, pGeneric.CIU_CapacidadPago, pGeneric.CIU_CorreoElectronico);
        }

        public override void Baja(Ciudadano pGeneric)
        {
            Ejecutar("SP_SIM_CIUDADANO_D", pGeneric.CIU_IDCiudadano);
        }

        public override Ciudadano ObtenerEntidad(Ciudadano pGeneric)
        {
            /*
            Ciudadano _entidad;
            using (var reader = ObtenerDataReader("SP_SIM_CIUDADANO_S", pGeneric.CIU_IDCiudadano))
            {
                _entidad = ObtenerPrimero(reader);
               
            }

            return _entidad;*/

            return ObtenerPrimero("SP_SIM_CIUDADANO_S", pGeneric.CIU_IDCiudadano);

        }

        public override List<Ciudadano> ObtenerListado(Ciudadano pGeneric)
        {     
            return ObtenerLista("SP_SIM_Ciudadano_S", pGeneric.CIU_IDCiudadano);       
        }

        public List<Ciudadano> ObtenerListadoCURPNOMBRE(Ciudadano pGeneric)
        {
            return ObtenerLista("SP_SIM_Ciudadano_S_B", pGeneric.CIU_CURP);
        }

    }
}
