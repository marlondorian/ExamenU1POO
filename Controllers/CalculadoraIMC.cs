using Microsoft.AspNetCore.Mvc;

namespace Ejercicios
{
    [Route("api/salud")]
    [ApiController]
    
    public class Calculadora_IMC : ControllerBase
        {
            [HttpGet("imc")]
            public  ActionResult CalcularIMC(double peso, double altura)
            {
                if (altura <= 0)
                {
                    return BadRequest("La altura debe ser mayor que cero.");
                }

                double imc = peso / (altura * altura);

                string clasificacion = "";

                if (imc < 18.5)
                {
                    clasificacion = "Bajo peso";
                }
                else if (imc < 25)
                {
                    clasificacion = "Peso normal";
                }
                else if (imc < 30)
                {
                    clasificacion = "Sobrepeso";
                }
                else
                {
                    clasificacion = "Obesidad";
                }

                var response = new IMCResponse
                {
                    Peso = peso,
                    Altura = altura,
                    IMC = imc,
                    Clasificacion = clasificacion
                };

                return Ok(response);
            }
        }
        public class IMCResponse
        {
            public double Peso { get; set; }
            public double Altura { get; set; }
            public double IMC { get; set; }
            public string Clasificacion { get; set; }
        }
            
        
    
}