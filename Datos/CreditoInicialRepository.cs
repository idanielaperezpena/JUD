using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CreditoInicialRepository : RepositoryBase<CreditoInicial>
    {
        public CreditoInicialRepository(DatabaseContext context) : base(context)
        {
        }

        public override CreditoInicial Alta(CreditoInicial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CreditoInicial_IU"
                , pGeneric.CI_IDCreditoInicial, pGeneric.CI_FolioSolicitud, pGeneric.CI_IDCiudadano
                , pGeneric.CI_FechaCaptura, pGeneric.CI_FechaSolicitud, pGeneric.CI_IDSeccionElectoral
                , pGeneric.CI_IDDomicilio, pGeneric.CI_IDSesionComite, pGeneric.CI_IDMejoramiento
                , pGeneric.CI_FolioCredito, pGeneric.CI_Ingreso, pGeneric.CI_ComprobanteIngresos, pGeneric.CI_CartaResponsiva);
        }

        public override void Baja(CreditoInicial pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CreditoInicial ObtenerEntidad(CreditoInicial pGeneric)
        {
            CreditoInicial _entidad;

            using (var reader = ObtenerDataReader("SP_SIM_CreditoInicial_S", pGeneric.CI_IDCreditoInicial))
            {
                _entidad = ObtenerPrimero(reader);
              
            }

            return _entidad;

        }

        public override List<CreditoInicial> ObtenerListado(CreditoInicial pGeneric)
        {
            return ObtenerLista("SP_SIM_CreditoInicial_S"
                , pGeneric.CI_IDCreditoInicial);
        }
    }
}
