using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DeudorSolidarioRepository : RepositoryBase<DeudorSolidario>
    {
        public DeudorSolidarioRepository(DatabaseContext context) : base(context)
        {
        }

        public override DeudorSolidario Alta(DeudorSolidario pGeneric)
        {
            return ObtenerPrimero("SP_SIM_DeudorSolidario_IU", pGeneric.DEU_ApellidoMaterno, pGeneric.DEU_ApellidoPaterno, pGeneric.DEU_CapacidadPago
                , pGeneric.DEU_CURP, pGeneric.DEU_FechaSolicitud, pGeneric.DEU_IDDeudorSolidario, pGeneric.DEU_IDDomicilio, pGeneric.DEU_IDDomicilioTrabajo
                , pGeneric.DEU_IDEstadoCivil, pGeneric.DEU_IDGenero, pGeneric.DEU_IDProfesion, pGeneric.DEU_Ingreso, pGeneric.DEU_Nombre
                , pGeneric.DEU_NombreTrabajo, pGeneric.DEU_Telefono, pGeneric.DEU_IDCiudadano);
        }

        public override void Baja(DeudorSolidario pGeneric)
        {
            throw new NotImplementedException();
        }

        public override DeudorSolidario ObtenerEntidad(DeudorSolidario pGeneric)
        {
            return ObtenerPrimero("SP_SIM_DeudorSolidario_S", pGeneric.DEU_IDCiudadano);
        }

        public override List<DeudorSolidario> ObtenerListado(DeudorSolidario pGeneric)
        {
            return ObtenerLista("SP_SIM_DeudorSolidario_S", pGeneric.DEU_ApellidoMaterno, pGeneric.DEU_ApellidoPaterno, pGeneric.DEU_CapacidadPago
                , pGeneric.DEU_CURP, pGeneric.DEU_FechaSolicitud, pGeneric.DEU_IDDeudorSolidario, pGeneric.DEU_IDDomicilio, pGeneric.DEU_IDDomicilioTrabajo
                , pGeneric.DEU_IDEstadoCivil, pGeneric.DEU_IDGenero, pGeneric.DEU_IDProfesion, pGeneric.DEU_Ingreso, pGeneric.DEU_Nombre
                , pGeneric.DEU_NombreTrabajo, pGeneric.DEU_Telefono);
        }
    }
}
