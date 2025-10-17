using CrudToAlgo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudToAlgo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesafiosController : ControllerBase
    {
        private readonly IDesafioService _service;

        public DesafiosController(IDesafioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var desafios = await _service.GetAllAsync();
            return Ok(desafios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var desafio = await _service.GetByIdAsync(id);
            if (desafio == null) return NotFound();
            return Ok(desafio);
        }
    }
}
