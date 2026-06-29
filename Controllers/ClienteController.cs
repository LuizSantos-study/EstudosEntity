using EntityWebSelect.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EntityWebSelect.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _repository.ClienteComPedidosItensAsync(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }
    }
}