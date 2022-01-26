using ApiClubDeportivo.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClubDeportivo.Resultados;

namespace ApiClubDeportivo.Controllers
{
    [ApiController]
    [EnableCors("Progra3")]
    public class DeporteController : ControllerBase
    {
        private readonly parcialProg3SociosContext db = new parcialProg3SociosContext();


        [HttpGet]
        [Route("Deporte/ObtenerDeporte")]
        public ActionResult<ResultadosAPI> GetCurso()
        {
            var resultado = new ResultadosAPI();
            try
            {
                resultado.Ok = true;
                resultado.Return = db.Deportes.ToList();
                resultado.InfoAdicional = "Se cargó el deporte correctamente";
                resultado.CodigoError = 200;
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Error = "Error al cargar deporte" + ex.Message;
                resultado.CodigoError = 400;
                return resultado;
            }
        }
    }
}
