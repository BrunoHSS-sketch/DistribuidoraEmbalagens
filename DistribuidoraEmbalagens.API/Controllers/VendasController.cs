using DistribuidoraEmbalagens.Application.DTOs;
using DistribuidoraEmbalagens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DistribuidoraEmbalagens.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendasController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaDTO>>> GetTodas()
        {
            var vendas = await _vendaService.GetAllAsync();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendaDTO>> GetPorId(int id)
        {
            var venda = await _vendaService.GetByIdAsync(id);
            if (venda == null) return NotFound();
            return Ok(venda);
        }

        [HttpPost]
        public async Task<ActionResult<VendaDTO>> Registrar(VendaCreateDTO dto)
        {
            try
            {
                var novaVenda = await _vendaService.RegistrarVendaAsync(dto);
                return CreatedAtAction(nameof(GetPorId), new { id = novaVenda.Id }, novaVenda);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
