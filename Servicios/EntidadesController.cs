using Microsoft.AspNetCore.Mvc;
using Infraestructura;

namespace Servicios
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntidadesController : ControllerBase
    {
        private readonly FileService _fileService;

        public EntidadesController()
        {
            _fileService = new FileService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entidades = _fileService.GetEntidades();
            return Ok(entidades);
        }
    }
}