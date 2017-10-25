using Microsoft.AspNetCore.Mvc;

namespace ManageIt.Api.Controllers
{
    [Route("api/error")]
    public class ErrorController : Controller
    {
        [HttpGet("/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            string statusMessage = string.Empty;
            switch (statusCode)
            {
                case 400:
                    return BadRequest("A requisição não pode ser processada por sintaxe incorreta");
                case 403:
                    return Forbid("Proibido");
                case 404:
                    return NotFound("A página solicitada não foi encontrado");
                default:
                    return BadRequest("Houve um problema não conhecido na requisição");
            }
        }
    }
}