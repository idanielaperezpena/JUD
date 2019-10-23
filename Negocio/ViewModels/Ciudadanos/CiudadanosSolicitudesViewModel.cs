using Entidades;
using Negocio.ViewModels.DomicilioCiudadano;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels.Ciudadanos
{
    public class CiudadanosSolicitudesViewModel
    {
        public DomicilioFormViewModel Domicilio { get; set; }


        public CiudadanosSolicitudesViewModel() {
            Domicilio = new DomicilioFormViewModel();
        }

    }
}
