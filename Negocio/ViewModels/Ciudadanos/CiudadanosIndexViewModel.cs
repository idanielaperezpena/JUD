using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ViewModels
{
    public class CiudadanosIndexViewModel
    {

        public List<CiudadanosIndexListadoViewModel> Listado { get; set; }

        public CiudadanosIndexViewModel()
        {
            Listado = new List<CiudadanosIndexListadoViewModel>();
        }

    }

    public class CiudadanosIndexListadoViewModel : Entidades.Ciudadano
    {
        public string IDEncriptado { get; set; }

        [Display(Name = "CURP")]
        public string CURP { get; set; }

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }

        [Display(Name = "Género")]
        public string GeneroTexto { get; set; }

        [Display(Name = "Datos de Nacimiento")]
        public string DatosNacimiento { get; set; }

        [Display(Name = "Contacto")]
        public string Contacto { get; set; }

        [Display(Name = "Domicilio")]
        public string DomicilioCompleto { get; set; }
    }
}
