﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels
{
    public class CatalogosIndexViewModel
    {

        public List<CatalogosIndexListadoViewModel> Listado { get; set; }

        public CatalogosIndexViewModel()
        {
            Listado = new List<CatalogosIndexListadoViewModel>();
        }

    }

    public class CatalogosIndexListadoViewModel : Entidades.Catalogos
    {
        [Display(Name = "Nombre del Catálogo")]
        public string NombreCatalogo_Mostrar { get; set; }

        [Display(Name = "No. del Catálogo")]
        public string NoCatalogo { get; set; }

        public string Color_Caja { get; set; }
    }
}
