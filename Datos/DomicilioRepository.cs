using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DomicilioRepository : RepositoryBase<Domicilio>
    {
        public DomicilioRepository(DatabaseContext context) : base(context)
        {
        }

        public override Domicilio Alta(Domicilio pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Domicilio_IU", pGeneric.DOM_CodigoPostal, pGeneric.DOM_Colonia, pGeneric.DOM_IDAlcaldia
                , pGeneric.DOM_IDDomicilio, pGeneric.DOM_IDEstado, pGeneric.DOM_IDVialidad, pGeneric.DOM_Latitud, pGeneric.DOM_Longitud
                , pGeneric.DOM_Lote, pGeneric.DOM_Manzana, pGeneric.DOM_NombreVialidad, pGeneric.DOM_NumeroExterior, pGeneric.DOM_NumeroInterior
                );
        }

        public override void Baja(Domicilio pGeneric)
        {
            throw new NotImplementedException();
        }

        public override Domicilio ObtenerEntidad(Domicilio pGeneric)
        {
            return ObtenerPrimero("SP_SIM_Domicilio_S", pGeneric.DOM_IDDomicilio);
        }

        public override List<Domicilio> ObtenerListado(Domicilio pGeneric)
        {
            throw new NotImplementedException();
        }
    }
}
