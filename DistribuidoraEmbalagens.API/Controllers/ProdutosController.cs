using DistribuidoraEmbalagens.Application.DTOs;
using DistribuidoraEmbalagens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DistribuidoraEmbalagens.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetTodos()
        {
            var produtos = await _produtoService.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> GetPorId(int id)
        {
            var produto = await _produtoService.GetByIdAsync(id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Criar(ProdutoCreateDTO dto)
        {
            var novoProduto = await _produtoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetPorId), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, ProdutoCreateDTO dto)
        {
            var sucesso = await _produtoService.UpdateAsync(id, dto);
            if (!sucesso)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var sucesso = await _produtoService.DeleteAsync(id);
            if (!sucesso)
                return NotFound();
            return NoContent();
        }
    }
}
