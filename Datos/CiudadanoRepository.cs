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
            return ObtenerPrimero("SP_SIM_CIUDADANO_IU", pGeneric.CIU_ApellidoMaterno, pGeneric.CIU_ApellidoMaterno, pGeneric.CIU_CapacidadPago, pGeneric.CIU_CorreoElectronico
                , pGeneric.CIU_CreditosOtorgados, pGeneric.CIU_CURP, pGeneric.CIU_FechaNacimiento, pGeneric.CIU_IDCiudadano, pGeneric.CIU_IDDomicilio, pGeneric.CIU_IDDomicilioTrabajo
                , pGeneric.CIU_IDEstado, pGeneric.CIU_IDEstadoCivil, pGeneric.CIU_IDEstructuraFamiliar, pGeneric.CIU_IDGenero, pGeneric.CIU_IDGradoEstudios, pGeneric.CIU_IDgrupoEtnico
                , pGeneric.CIU_IDOcupacion, pGeneric.CIU_NumeroIdentificacion, pGeneric.CIU_IngresoFamiliar, pGeneric.CIU_Nombre, pGeneric.CIU_NombreTrabajo
                , pGeneric.CIU_Proposito, pGeneric.CIU_TelCelular, pGeneric.CIU_TelParticular, pGeneric.CIU_TelRecados, pGeneric.CIU_TelTrabajo, pGeneric.CIU_TiempoResidencia);
        }

        public override void Baja(Ciudadano pGeneric)
        {
            Ejecutar("SP_SIM_CIUDADANO_D", pGeneric.CIU_IDCiudadano);
        }

        public override Ciudadano ObtenerEntidad(Ciudadano pGeneric)
        {
            Ciudadano _entidad;
            using (var reader = ObtenerDataReader("SP_SIM_CIUDADANO_S", pGeneric.CIU_IDCiudadano))
            {
                _entidad = ObtenerPrimero(reader);
               
            }

            return _entidad;

        }

        public override List<Ciudadano> ObtenerListado(Ciudadano pGeneric)
        {
            /*
            var dateString = "2/04/1997";
            DateTime date1 = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Ciudadano persona1 = new Ciudadano
            {
                CIU_IDCiudadano = 1,
                CIU_CURP = "CURP 1",
                CIU_Nombre = "Daniela",
                CIU_ApellidoPaterno = "Perez",
                CIU_ApellidoMaterno = "Peña",
                CIU_IDGenero = 1,
                CIU_FechaNacimiento = date1,
                CIU_TelParticular = "134",
                CIU_IDDomicilio = 1
            };


            var dateString2 = "3/04/1997";
            DateTime date2 = DateTime.Parse(dateString2,
                                      System.Globalization.CultureInfo.InvariantCulture);
            Ciudadano persona2 = new Ciudadano
            {
                CIU_IDCiudadano = 2,
                CIU_CURP = "CURP 2",
                CIU_Nombre = "Carlos",
                CIU_ApellidoPaterno = "Ascencio",
                CIU_ApellidoMaterno = "Cuevas",
                CIU_IDGenero = 1,
                CIU_FechaNacimiento = date2,
                CIU_TelParticular = "54321",
                CIU_IDDomicilio = 2
            };

            List<Ciudadano> lista = new List<Ciudadano>();
            lista.Add(persona1);
            lista.Add(persona2);

            return lista;*/

            
            return ObtenerLista("SP_SIM_Ciudadano_S", pGeneric.CIU_IDCiudadano);
            
        }
    }
}
