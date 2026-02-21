using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicios
{
    [Route("api/seguridad/validar-password")]
    [ApiController]
    
    public class ValidarPassword : ControllerBase
        {
            [HttpPost]
            public IActionResult Validar(ValidarPasswordRequest request)    
            {
                bool esValida = true;
                string pass = request.password;
                if (pass.Length < 8) esValida = false;
                if (!Regex.IsMatch(pass, "[A-Z]")) esValida = false;
                if (!Regex.IsMatch(pass, "[a-z]")) esValida = false;
                if (!Regex.IsMatch(pass, "[0-9]")) esValida = false;
                if (!Regex.IsMatch(pass, "[^A-Za-z0-9]")) esValida = false;
                if (!esValida)
                {
                    return BadRequest(new ValidarPasswordResponse { mensaje = "La contraseña no cumple con los requisitos.", esValida = esValida });
                }
                return Ok(new ValidarPasswordResponse { mensaje = "La contraseña es válida.", esValida = esValida });
            }
        }
    public class ValidarPasswordRequest
        {
            public string password { get; set; }
        }
    public class ValidarPasswordResponse
        {
            public string mensaje { get; set; }
            public bool esValida { get; set; }
            public int MyProperty { get; set; }
        }
            
        
    
}