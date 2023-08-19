using System;
using Microsoft.AspNetCore.Mvc;
using NotePadAPI.Context;
using NotePadAPI.Entities;

namespace NotePadAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AnotacaoController : ControllerBase
	{
		private readonly NotePadContext _context;

		public AnotacaoController(NotePadContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult InsereAnotacao(Anotacao anotacao)
		{
			_context.Add(anotacao);
			_context.SaveChanges();

			return Ok(anotacao);
		}

		[HttpGet("{idAnotacao}")]
		public IActionResult ObterAnotacao(int idAnotacao)
		{
			var anotacaoBanco = _context.Anotacao.Find(idAnotacao);

			if (anotacaoBanco == null)
				return NotFound();

            return Ok(anotacaoBanco);
		}

        // Todo: implementar funcionalidade que retorna uma lista de anotações, por usuário
        [HttpGet("Usuario/{idUsuario}")]
        public IActionResult ObterAnotacaoPorUsuario(int idUsuario)
        {
            var anotacaoBanco = _context.Anotacao.Where(x => x.IdUsuario.Equals(idUsuario));

            return Ok(anotacaoBanco);
        }

        [HttpPut("AtualizaAnotacao/{idAnotacao}")]
		public IActionResult AtualizaAnotacao(int idAnotacao, Anotacao anotacao)
		{
			var anotacaoBanco = _context.Anotacao.Find(idAnotacao);

			if (anotacaoBanco == null)
				return NotFound("Anotação não encontrada");

			anotacaoBanco.Titulo = anotacao.Titulo;
			anotacaoBanco.Mensagem = anotacao.Mensagem;
			anotacaoBanco.DataAlteracao = DateTime.Now;

			_context.Anotacao.Update(anotacaoBanco);
			_context.SaveChanges();

			return Ok(anotacaoBanco);
		}

		// Todo: implementar exclusão de anotações
		[HttpDelete("DeletarAnotacao/{idAnotacao}")]
		public IActionResult ExcluiAnotacao(int idAnotacao)
		{
			var anotacaoBanco = _context.Anotacao.Find(idAnotacao);

			if (anotacaoBanco == null)
				return NotFound("Anotação não encontrada");

			_context.Anotacao.Remove(anotacaoBanco);
			_context.SaveChanges();

			return NoContent();
		}
	}
}

