using JUDMB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace JUDMB.Funciones
{
    public class Validar_Login
    {
        HttpClient client = new HttpClient();

        public Validar_Login(string token)
        {
            client.DefaultRequestHeaders.Add("TokenINVI", token);

        }

        public async Task<bool> Verificar_LoginAsync()
        {
            
            var response = await client.GetAsync("http://localhost:54971/api/Empleado/IsLogin");
            var responseString = await response.Content.ReadAsAsync<Boolean>();
            return responseString;
        }

        public async Task<Empleado> Datos_Logeado()
        {
            var response = await client.GetAsync("http://localhost:54971/api/Empleado/Getlogeado" );
            var responseString = await response.Content.ReadAsAsync<Empleado>();
            return responseString;
        }


    }
}
