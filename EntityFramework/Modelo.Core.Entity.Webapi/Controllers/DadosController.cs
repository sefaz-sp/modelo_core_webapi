using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using modelo.projetos;
using Modelo.Core.Entity.Webapi.Contexto;

namespace Modelo.Core.Entity.Webapi.Controllers
{
    [Authorize] //Retirado até que se descubra o porquê de não estar funcionando a autenticação da api
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetosContext _context;
        private IConfiguration _configuration;
        private Usuario _usuario { get; }

        public ProjetosController(ProjetosContext context, IConfiguration configuration, Usuario usuario)
        {
            _context = context;
            _configuration = configuration;
            _usuario = usuario;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projetos>>> GetProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("status")]
        public ActionResult<string> TesteAcesso()
        {
            var resultado = "Informações da API - "
                            + "build: " + _configuration["dadosdeploy:build"]
                            + " | release: " + _configuration["dadosdeploy:release"]
                            + " | ambiente: " + _configuration["dadosdeploy:ambiente"]
                            + " | tipo de deploy: " + _configuration["dadosdeploy:tipodeploy"]
                            + " | plataforma: " + _configuration["dadosdeploy:plataforma"];

            if (_usuario != null && !string.IsNullOrEmpty(_usuario.Login))
            {
                resultado += " || " + "Usuário que chamou a api: "
                    + "Login " + _usuario.Login
                    + " - Nome " + _usuario.Nome
                    + " - Doc " + _usuario.DocumentoIdentificacao;
            }
            else
            {
                resultado += " || " + "Nenhum usuário autenticado. ";
            }

            return resultado;
        }

        [AllowAnonymous]
        [HttpGet("conexao")]
        public async Task<ActionResult<string>> TesteConexao()
        {
            var resultado = "Informações de conexão: ";
            resultado += _configuration["ConnectionStrings:DB_APLICACAO_MODELO"];
            try
            {
                var listaProjetos = await _context.Projetos.ToListAsync();
                resultado += " | Acesso ao banco de dados: Ok";
            }
            catch (Exception e)
            {

                if (e.Source != null)
                    resultado += " | Falha de acesso ao banco de dados: " + e.ToString();
            }
            return resultado;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projetos>> GetProjetos(long id)
        {
            if (!ProjetoExists(id))
            {
                return NotFound();
            }
            var projetos = await _context.Projetos.FindAsync(id);

            return projetos;
        }

        [HttpPut]
        public async Task<ActionResult<Projetos>> PutProjetos(Projetos projetos)
        {
            _context.Entry(projetos).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return projetos;
        }

        [HttpPost]
        public async Task<ActionResult<Projetos>> PostProjetos(Projetos projetos)
        {
            _context.Projetos.Add(projetos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjetos", new { id = projetos.cd_projeto }, projetos);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Projetos>> DeleteProjetos(long id)
        {
            if (!ProjetoExists(id))
            {
                return NotFound();
            }

            var projetos = await _context.Projetos.FindAsync(id);
            _context.Projetos.Remove(projetos);
            await _context.SaveChangesAsync();

            return projetos;
        }

        private bool ProjetoExists(long id)
        {
            return _context.Projetos.Any(e => e.cd_projeto == id);
        }
    }
}
