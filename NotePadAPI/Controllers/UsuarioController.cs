using System;
using Microsoft.AspNetCore.Mvc;
using NotePadAPI.Context;
using NotePadAPI.Entities;

namespace NotePadAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly NotePadContext _context;

        public UsuarioController(NotePadContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriaUsuario(Usuario usuario)
        {
            var nomeUsuario = _context.Usuario.Where(x => x.NomeUsuario.Contains(usuario.NomeUsuario));
            var email = _context.Usuario.Where(x => x.Email.Contains(usuario.Email));

            if (nomeUsuario.Any())
                return BadRequest(new { Erro = "Nome de Usuário já cadastrado" });

            if (email.Any())
                return BadRequest(new { Erro = "Email já cadastrado" });

            _context.Add(usuario);
            _context.SaveChanges();

            return Ok(usuario);
        }

        // Todo: implementar login de usuário
        [HttpGet("LoginUsuario")]
        public IActionResult LoginUsuario(string nomeUsuario, string senhaUsuario)
        {
            var usuario = _context.Usuario.Where(x => x.NomeUsuario.Contains(nomeUsuario) && x.SenhaUsuario.Contains(senhaUsuario));

            if (!usuario.Any())
                return NotFound("Usuário não encontrado ou senha incorreta");

            return Ok(usuario);
        }

        // Todo: implementar atualização de usuário
        [HttpPut("AtualizarUsuario/{idUsuario}")]
        public IActionResult AtualizaUsuario(int idUsuario, Usuario usuario)
        {
            var usuarioBanco = _context.Usuario.Find(idUsuario);

            if (usuarioBanco == null)
                return NotFound("Usuário não encontrado");

            usuarioBanco.Ativo = usuario.Ativo;
            usuarioBanco.Email = usuario.Email;
            usuarioBanco.SenhaUsuario = usuario.SenhaUsuario;

            _context.Usuario.Update(usuarioBanco);
            _context.SaveChanges();

            return Ok(usuarioBanco);
        }
    }
}
