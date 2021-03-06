﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CCDictamenSocialRepository : RepositoryBase<CCDictamenSocial>
    {
        public CCDictamenSocialRepository(DatabaseContext context) : base(context)
        {
        }

        public override CCDictamenSocial Alta(CCDictamenSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CC_DictamenSocial_IU"
                , pGeneric.CCDS_IDDictamenSocial, pGeneric.CCDS_IDCreditoComplementario, pGeneric.CCDS_IDTipoPredio
                , pGeneric.CCDS_IDCaracteristicasPredio, pGeneric.CCDS_NoFamiliasLote, pGeneric.CCDS_NoFamiliasVivienda, pGeneric.CCDS_NoViviendasLote
                , pGeneric.CCDS_NoPersonasVivienda, pGeneric.CCDS_IDServicioAgua, pGeneric.CCDS_IDServicioDrenaje, pGeneric.CCDS_IDServicioElectrico
                , pGeneric.CCDS_Desdoblamiento, pGeneric.CCDS_BanoCompartido, pGeneric.CCDS_CocinaCompartido, pGeneric.CCDS_IDHacinamiento
                , pGeneric.CCDS_IDInsalubridad, pGeneric.CCDS_OtroInsalubridad, pGeneric.CCDS_FechaVisita, pGeneric.CCDS_Observaciones, pGeneric.CCDS_NoEmpleadoVisita
                , pGeneric.CCDS_Procedencia, pGeneric.CCDS_IDVulnerabilidad, pGeneric.CCDS_MotivosProcedencia, pGeneric.CCDS_FechaDictaminacion, pGeneric.CCDS_UsuarioDominio);
        }

        public override void Baja(CCDictamenSocial pGeneric)
        {
            throw new NotImplementedException();
        }

        public override CCDictamenSocial ObtenerEntidad(CCDictamenSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_CC_DictamenSocial_S", pGeneric.CCDS_IDCreditoComplementario);
        }

        public override List<CCDictamenSocial> ObtenerListado(CCDictamenSocial pGeneric)
        {
            return ObtenerLista("SP_SIM_CC_DictamenSocial_S", pGeneric.CCDS_IDCreditoComplementario);
        }
    }
}
