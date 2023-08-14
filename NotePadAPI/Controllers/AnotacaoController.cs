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
		public IActionResult InsereNota(Anotacao anotacao)
		{
			_context.Add(anotacao);
			_context.SaveChanges();

			return Ok(anotacao);
		}
	}
}

