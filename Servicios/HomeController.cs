using Microsoft.AspNetCore.Mvc;

namespace Servicios
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API RESTful funcionando. Usa /api/Entidades para ver las entidades.");
        }
    }
}