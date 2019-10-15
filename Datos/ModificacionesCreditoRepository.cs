using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class ModificacionesCreditoRepository : RepositoryBase<ModificacionesCredito>
    {
        public ModificacionesCreditoRepository(DatabaseContext context) : base(context)
        {
        }

        public override ModificacionesCredito Alta(ModificacionesCredito pGeneric)
        {
            return ObtenerPrimero("SP_SIM_ModificacionesCredito_IU", pGeneric.MC_FechaCaptura, pGeneric.MC_FechaSolicitud, pGeneric.MC_FolioSolicitud
                , pGeneric.MC_IDCiudadano, pGeneric.MC_IDCreditoInicial, pGeneric.MC_IDModificacionesCredito, pGeneric.MC_IDProblema
                , pGeneric.MC_IDTipoSolicitante, pGeneric.MC_Ingreso, pGeneric.MC_Procedencia);
        }

        public override void Baja(ModificacionesCredito pGeneric)
        {
            throw new NotImplementedException();
        }

        public override ModificacionesCredito ObtenerEntidad(ModificacionesCredito pGeneric)
        {
            ModificacionesCredito _entidad;

            using (var reader = ObtenerDataReader("SP_SIM_ModificacionesCredito_S", pGeneric.MC_IDModificacionesCredito))
            {
                _entidad = ObtenerPrimero(reader);
               
            }

            return _entidad;
        }

        public override List<ModificacionesCredito> ObtenerListado(ModificacionesCredito pGeneric)
        {
            return ObtenerLista("SP_SIM_ModificacionesCredito_S", pGeneric.MC_FechaCaptura, pGeneric.MC_FechaSolicitud, pGeneric.MC_FolioSolicitud
              , pGeneric.MC_IDCiudadano, pGeneric.MC_IDCreditoInicial, pGeneric.MC_IDModificacionesCredito, pGeneric.MC_IDProblema
              , pGeneric.MC_IDTipoSolicitante, pGeneric.MC_Ingreso, pGeneric.MC_Procedencia);
        }
    }
}
