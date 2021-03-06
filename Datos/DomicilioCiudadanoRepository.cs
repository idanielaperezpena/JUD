﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DomicilioCiudadanoRepository : RepositoryBase<DomicilioCiudadano>
    {
        public DomicilioCiudadanoRepository(DatabaseContext context) : base(context)
        {
        }

        public override DomicilioCiudadano Alta(DomicilioCiudadano pGeneric)
        {
            return ObtenerPrimero("SP_SIM_DomicilioCiudadano_IU",
                  pGeneric.DOMC_IDDomicilioCiudadano,pGeneric.DOMC_IDCiudadano, pGeneric.DOMC_IDVialidad, pGeneric.DOMC_NombreVialidad, pGeneric.DOMC_NumeroExterior
                , pGeneric.DOMC_NumeroInterior, pGeneric.DOMC_Manzana, pGeneric.DOMC_Lote, pGeneric.DOMC_Colonia, pGeneric.DOMC_IDAlcaldia
                , pGeneric.DOMC_CodigoPostal, pGeneric.DOMC_IDEstado, pGeneric.DOMC_Latitud, pGeneric.DOMC_Longitud, pGeneric.DOMC_MontoRenta
                , pGeneric.DOMC_IDTipoVivienda, pGeneric.DOMC_Otro);
        }

        public override void Baja(DomicilioCiudadano pGeneric)
        {
            throw new NotImplementedException();
        }

        public override DomicilioCiudadano ObtenerEntidad(DomicilioCiudadano pGeneric)
        {
            return ObtenerPrimero("SP_SIM_DomicilioCiudadano_S", pGeneric.DOMC_IDCiudadano);
        }

        public override List<DomicilioCiudadano> ObtenerListado(DomicilioCiudadano pGeneric)
        {
            return ObtenerLista("SP_SIM_DomicilioCiudadano_S", pGeneric.DOMC_IDCiudadano);
        }
    }
}
