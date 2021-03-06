﻿using Negocio;
using Negocio.ViewModels.CreditoComplementario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CreditoComplementarioController : BaseController
    {
        private CreditoComplementarioService _service;

        public CreditoComplementarioController()
        {
            _service = new CreditoComplementarioService(ModelState);
        }

        // GET: CreditoComplementario
        public ActionResult Index()
        {
           var _vm= _service.Index();
           ViewBag.Titulo = "Lista de Créditos Complementarios";
            _vm.user = this.Usuario;
            return View(_vm);
        }

        
        // GET: CreditoComplementario/Insertar
        public ActionResult Insertar(int IDCreditoInicial, string IDCreditoComplementario)
        {
            int? IDCreditoComplementario2=null;
            if (!String.IsNullOrEmpty(IDCreditoComplementario))
            {
                IDCreditoComplementario2 = Int32.Parse(IDCreditoComplementario);
            }
           var _vm=_service.Insertar(IDCreditoInicial, IDCreditoComplementario2);
            return View(_vm);
        }

        [HttpPost]
        [Permiso(Disabled = true)]
        public ActionResult Insertar(CreditoComplementarioInsertarViewModel _viewModel)
        {
            _service.EditCreditoComplementario(_viewModel);
            var errors = ModelState.Select(x => x.Value.Errors)
                     .Where(y => y.Count > 0)
                     .ToList();
            return Json(errors.ToJSON());

        }

       
    }
}
