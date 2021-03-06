﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MCDictamenSocialRepository : RepositoryBase<MCDictamenSocial>
    {
        public MCDictamenSocialRepository(DatabaseContext context) : base(context)
        {
        }

        public override MCDictamenSocial Alta(MCDictamenSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_MC_DictamenSocial_IU"
                , pGeneric.MCDS_IDDictamenSocial, pGeneric.MCDS_IDModificacionesCredito, pGeneric.MCDS_IDTipoPredio
                , pGeneric.MCDS_IDCaracteristicasPredio, pGeneric.MCDS_NoFamiliasLote, pGeneric.MCDS_NoFamiliasVivienda, pGeneric.MCDS_NoViviendasLote
                , pGeneric.MCDS_NoPersonasVivienda, pGeneric.MCDS_IDServicioAgua, pGeneric.MCDS_IDServicioDrenaje, pGeneric.MCDS_IDServicioElectrico
                , pGeneric.MCDS_Desdoblamiento, pGeneric.MCDS_BanoCompartido, pGeneric.MCDS_CocinaCompartido, pGeneric.MCDS_IDHacinamiento
                , pGeneric.MCDS_IDInsalubridad, pGeneric.MCDS_OtroInsalubridad, pGeneric.MCDS_FechaVisita, pGeneric.MCDS_Observaciones, pGeneric.MCDS_NoEmpleadoVisita
                , pGeneric.MCDS_Procedencia, pGeneric.MCDS_IDVulnerabilidad, pGeneric.MCDS_MotivosProcedencia, pGeneric.MCDS_FechaDictaminacion
                , pGeneric.MCDS_UsuarioDominio);
        }

        public override void Baja(MCDictamenSocial pGeneric)
        {
            throw new NotImplementedException();
        }

        public override MCDictamenSocial ObtenerEntidad(MCDictamenSocial pGeneric)
        {
            return ObtenerPrimero("SP_SIM_MC_DictamenSocial_S", pGeneric.MCDS_IDModificacionesCredito);
        }

        public override List<MCDictamenSocial> ObtenerListado(MCDictamenSocial pGeneric)
        {
            return ObtenerLista("SP_SIM_MC_DictamenSocial_S", pGeneric.MCDS_IDModificacionesCredito);
        }
    }
}
