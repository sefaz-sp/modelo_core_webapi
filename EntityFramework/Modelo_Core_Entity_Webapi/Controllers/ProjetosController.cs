using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Modelo.Core.Entity.Webapi.Contexto;
using Modelo.Core.Domain.Entities;

namespace Modelo.Core.Entity.Webapi.Controllers
{
    //[Authorize] //Retirado até que se descubra o porquê de não estar funcionando a autenticação da api
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetosContext _context;
        private IConfiguration Configuration;
        private Usuario _usuario { get; }

        public ProjetosController(ProjetosContext context, IConfiguration configuration, Usuario usuario)
        {
            _context = context;
            Configuration = configuration;
            _usuario = usuario;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetoEntity>>> GetProjetos()
        {
            return await _context.projetoEntity.ToListAsync();
        }

        [HttpGet("status")]
        public ActionResult<string> TesteAcesso()
        {
            var resultado = "Informações da API - "
                            + "build: " + Configuration["dadosdeploy:build"]
                            + " | release: " + Configuration["dadosdeploy:release"]
                            + " | ambiente: " + Configuration["dadosdeploy:ambiente"]
                            + " | tipo de deploy: " + Configuration["dadosdeploy:tipodeploy"]
                            + " | plataforma: " + Configuration["dadosdeploy:plataforma"];

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

        [HttpGet("conexao")]
        public async Task<ActionResult<string>> TesteConexao()
        {
            var resultado = "Informações de conexão: ";
            resultado += Configuration["ConnectionStrings:Projetos"];
            try
            {
                var listaProjetos = await _context.projetoEntity.ToListAsync();
                resultado += " | Acesso ao banco de dados: Ok";
            }
            catch (Exception e)
            {

                if (e.Source != null)
                    resultado += " | Falha de acesso ao banco de dados: " + e.ToString();
            }
            return resultado;
        }

        [HttpGet("{cd_projeto}")]
        public async Task<ActionResult<ProjetoEntity>> GetProjetos(int cd_projeto)
        {
            if (!ProjetoExists(cd_projeto))
            {
                return NotFound();
            }
            var projetos = await _context.projetoEntity.FindAsync(cd_projeto);

            return projetos;
        }

        [HttpPut]
        public async Task<ActionResult<ProjetoEntity>> PutProjetos(ProjetoEntity projetos)
        {
            _context.Entry(projetos).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return projetos;
        }

        [HttpPost]
        public async Task<ActionResult<ProjetoEntity>> PostProjetos(ProjetoEntity projetos)
        {
            _context.projetoEntity.Add(projetos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjetos", new { cd_projeto = projetos.cd_projeto }, projetos);
        }

        [HttpDelete("{cd_projeto}")]
        public async Task<ActionResult<ProjetoEntity>> DeleteProjetos(int cd_projeto)
        {
            if (!ProjetoExists(cd_projeto))
            {
                return NotFound();
            }

            var projetos = await _context.projetoEntity.FindAsync(cd_projeto);
            _context.projetoEntity.Remove(projetos);
            await _context.SaveChangesAsync();

            return projetos;
        }

        private bool ProjetoExists(int cd_projeto)
        {
            return _context.projetoEntity.Any(e => e.cd_projeto == cd_projeto);
        }
    }
}
