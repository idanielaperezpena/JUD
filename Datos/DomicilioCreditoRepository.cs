using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class DomicilioCreditoRepository : RepositoryBase<DomicilioCredito>
    {
        public DomicilioCreditoRepository(DatabaseContext context) : base(context)
        {
        }

        public override DomicilioCredito Alta(DomicilioCredito pGeneric)
        {
            return ObtenerPrimero("SP_SIM_DomicilioCredito_IU", pGeneric.DOMC_CodigoPostal, pGeneric.DOMC_Colonia, pGeneric.DOMC_IDAlcaldia
                , pGeneric.DOMC_IDDomicilio, pGeneric.DOMC_IDEstado, pGeneric.DOMC_IDVialidad, pGeneric.DOMC_Latitud, pGeneric.DOMC_Longitud
                , pGeneric.DOMC_Lote, pGeneric.DOMC_Manzana, pGeneric.DOMC_NombreVialidad, pGeneric.DOMC_NumeroExterior, pGeneric.DOMC_NumeroInterior
                , pGeneric.DOMC_Otro);
        }

        public override void Baja(DomicilioCredito pGeneric)
        {
            throw new NotImplementedException();
        }

        public override DomicilioCredito ObtenerEntidad(DomicilioCredito pGeneric)
        {
            return ObtenerPrimero("SP_SIM_DomicilioCredito_S", pGeneric.DOMC_IDDomicilio);
        }

        public override List<DomicilioCredito> ObtenerListado(DomicilioCredito pGeneric)
        {
            throw new NotImplementedException();
        }
    }
}
