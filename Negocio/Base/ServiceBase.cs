using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Negocio
{
    public class ServiceBase
    {
        protected UnitOfWork UoW { get; private set; }
        protected ModelStateDictionary ModelState { get; private set; }
        protected TempDataDictionary TempData { get; private set; }

        public ServiceBase(ModelStateDictionary modelState)
        {
            UoW = new UnitOfWork();
            ModelState = modelState;
        }

        public ServiceBase()
        {
            UoW = new UnitOfWork();
        }

        public ServiceBase(ModelStateDictionary modelState, TempDataDictionary tempData) : this(modelState)
        {
            TempData = tempData;
        }
    }
}
