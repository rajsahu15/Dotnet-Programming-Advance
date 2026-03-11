using Microsoft.AspNetCore.Mvc;
using ImprovedApiProject.Services;
using ImprovedApiProject.DTOs;

namespace ImprovedApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _service.GetClientsAsync();
            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientDTO dto)
        {
            var result = await _service.AddClientAsync(dto);
            return Ok(result);
        }
    }
}