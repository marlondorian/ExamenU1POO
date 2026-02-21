using Microsoft.AspNetCore.Mvc;

namespace Ejercicios
{
    [Route("api/matematicas")]
    [ApiController]
    public class TablaMultiplicar : ControllerBase
    {
        [HttpGet("tabla/{numero}")]
        public ActionResult CalcularTabla(int numero, int hasta)
        {
            if (hasta <= 0)
            {
                return BadRequest("El límite debe ser mayor que cero.");
            }

            var tabla = new List<string>();
            for (int i = 1; i <= hasta; i++)
            {
                tabla.Add($"{numero} x {i} = {numero * i}");
            }

            return Ok(new TablaMultiplicarResponse { Numero = numero, Hasta = hasta, Tabla = tabla });
        }
    }
    public class TablaMultiplicarResponse
    {
        public int Numero { get; set; }
        public int Hasta { get; set; }
        public List<string> Tabla { get; set; }
    }
}