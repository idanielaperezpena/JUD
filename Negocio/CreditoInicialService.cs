using Entidades;
using Entidades.Utilidades;
using Negocio.ViewModels;
using Negocio.ViewModels.Ciudadanos;
using Negocio.ViewModels.CreditoInicial;
using Negocio.ViewModels.DomicilioCiudadano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Mvc;

namespace Negocio
{
    public class CreditoInicialService : ServiceBase
    {
        public CreditoInicialService(ModelStateDictionary modelState) : base(modelState) { }

        //Vistas
        public CreditoInicialNuevoViewModel Nuevo()
        {
            return new CreditoInicialNuevoViewModel();
        }


        //Funciones

    }
}
