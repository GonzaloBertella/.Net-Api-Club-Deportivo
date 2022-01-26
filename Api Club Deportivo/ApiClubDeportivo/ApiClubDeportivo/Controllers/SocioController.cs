using ApiClubDeportivo.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClubDeportivo.Resultados;
using ApiClubDeportivo.Comandos;

namespace ApiClubDeportivo.Controllers
{
    [ApiController]
    [EnableCors("Progra3")]

    public class SocioController : ControllerBase
    {

        private readonly parcialProg3SociosContext db = new parcialProg3SociosContext();

        [HttpPost]
        [Route("Socio/CrearSocio")]
        public ActionResult<ResultadosAPI> CrearSocio([FromBody] ComandoCrearSocio comando)
        {
            var resultado = new ResultadosAPI();
            if (comando.Nombre.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese un Nombre";
                resultado.CodigoError = 2;
                return resultado;
            }
            if (comando.Apellido.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese un Apellido";
                resultado.CodigoError = 3;
                return resultado;
            }
            if (comando.Calle.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese una Calle";
                resultado.CodigoError = 4;
                return resultado;
            }
            if (comando.Numero.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese un Numero";
                resultado.CodigoError = 5;
                return resultado;
            }
            var socio = new Socio(); 
            socio.Nombre = comando.Nombre;
            socio.Apellido = comando.Apellido;
            socio.Calle = comando.Calle;
            socio.Numero = comando.Numero;
            socio.IdDeporte = comando.IdDeporte;
            db.Socios.Add(socio);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.Socios.ToList();
            return resultado;
        }

        [HttpGet]
        [Route("Socio/ObtenerSocio")]
        public ActionResult<ResultadosAPI> GetCurso()
        {
            var resultado = new ResultadosAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.Socios.ToList();
                resultado.InfoAdicional = "Se cargó el socio correctamente";
                resultado.CodigoError = 200;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar socio" + ex.Message;
                resultado.CodigoError = 400;
                return resultado;
            }
        }



    }
}
