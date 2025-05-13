using ControleFinanceiro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControleFinanceiro.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InformacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult>CriarTransacao([FromBody] TransacaoModel transacao)
        {
            if (transacao == null)
            {
                return BadRequest("Transação inválida.");
            }
            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CriarTransacao), new { id = transacao.TransacaoId }, transacao);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoModel>>> ObterTransacoes()
        {
            var transacoes = await _context.Transacoes.ToListAsync();
            return Ok(transacoes);
        }

        [HttpPatch]
        public async Task<ActionResult> AtualizarTransacao(string transacaoId, [FromBody] TransacaoPatchDTO dto)
        {
            var transacao = await _context.Transacoes.FindAsync(transacaoId);

            if (transacao == null)
            {
                return NotFound();
            }

            if (dto.Valor.HasValue)
            {
                transacao.Valor = dto.Valor.Value;
            }
            if (dto.Data.HasValue)
            {
                transacao.Data = dto.Data.Value;
            }
            if (dto.CategoriaId.HasValue)
            {
                transacao.CategoriaId = dto.CategoriaId.Value;
            }

            await _context.SaveChangesAsync();

            return Ok(transacao);
        }

    }
}
