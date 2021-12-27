using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelo.Core.ADO.WebApi.Models;
using Modelo.Core.Domain.Entities;
using Modelo.Core.Domain.Interfaces;
using Modelo.Core.Service.Validators;
using System;
using System.Collections.Generic;

namespace Modelo.Core.ADO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private IConfiguration _configuration;
        private IBaseService<ProjetoEntity> _projetoService;

        public ProjetosController(IConfiguration configuration, IBaseService<ProjetoEntity> projetoService)
        {
            _configuration = configuration;
            _projetoService = projetoService;
        }

        /// GET /api/projetos
        /// <summary>
        /// Lista todos os projetos
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET /api/projetos
        ///     
        /// </remarks>
        /// <returns>Lista de projetos cadastrados</returns>
        /// <response code="200">Retorna lista de projetos</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IList<ProjetoModel>> Listar()
        {
            var projetos = _projetoService.Listar();

            var model = new List<ProjetoModel>();

            if (projetos != null)
            {
                foreach (var p in projetos)
                {
                    model.Add(p.ToModel());
                }
            }

            return Ok(model);
        }

        //[HttpGet("status")]
        //public ActionResult<string> TesteAcesso()
        //{
        //    var resultado = "Informações da API - "
        //                    + "build: " + Configuration["dadosdeploy:build"]
        //                    + " | release: " + Configuration["dadosdeploy:release"]
        //                    + " | ambiente: " + Configuration["dadosdeploy:ambiente"]
        //                    + " | tipo de deploy: " + Configuration["dadosdeploy:tipodeploy"]
        //                    + " | plataforma: " + Configuration["dadosdeploy:plataforma"];

        //    if (_usuario != null && !string.IsNullOrEmpty(_usuario.Login))
        //    {
        //        resultado += " || " + "Usuário que chamou a api: "
        //            + "Login " + _usuario.Login
        //            + " - Nome " + _usuario.Nome
        //            + " - Doc " + _usuario.DocumentoIdentificacao;
        //    }
        //    else
        //    {
        //        resultado += " || " + "Nenhum usuário autenticado. ";
        //    }

        //    return resultado;
        //}

        //[HttpGet("conexao")]
        //public async Task<ActionResult<string>> TesteConexao()
        //{
        //    var resultado = "Informações de conexão: ";
        //    resultado += Configuration["ConnectionStrings:Projetos"];
        //    try
        //    {
        //        var listaProjetos = await _context.Projetos.ToListAsync();
        //        resultado += " | Acesso ao banco de dados: Ok";
        //    }
        //    catch (Exception e)
        //    {

        //        if (e.Source != null)
        //            resultado += " | Falha de acesso ao banco de dados: " + e.ToString();
        //    }
        //    return resultado;
        //}

        /// GET /api/projetos/{id}
        /// <summary>
        /// Consulta um projeto.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     GET /api/projetos/{id}
        ///     
        /// </remarks>
        /// <returns>Dados de um projeto cadastrado</returns>
        /// <response code="200">Retorna os dados de um projeto</response>
        /// <response code="400">Erro ao processar solicitação</response>
        /// <response code="404">Quando não existe projeto com o id informado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProjetoModel> Consultar(int id)
        {
            var projeto = _projetoService.Consultar(id);

            if (projeto == null || projeto.Id == 0)
            {
                return NotFound();
            }

                var model = projeto.ToModel();

            return Ok(model);
        }

        /// DELETE /api/projetos/{id}
        /// <summary>
        /// Exclui um projeto.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     DELETE /api/projetos/{id}
        ///     
        /// </remarks>
        /// <returns>Dados de um projeto cadastrado</returns>
        /// <response code="200">Retorna os dados de um projeto</response>
        /// <response code="400">Erro ao processar solicitação</response>
        /// <response code="404">Quando não existe projeto com o id informado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProjetoModel> Excluir(int id)
        {
            _projetoService.Excluir(id);

            return null;

        }

        /// PUT /api/projetos
        /// <summary>
        /// Altera os dados de um projeto.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     PUT /api/projetos
        ///     
        /// </remarks>
        /// <returns>OK</returns>
        /// <response code="200">Informa que o projeto foi alterado</response>
        /// <response code="400">Erro ao processar solicitação</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Alterar(ProjetoModel projeto)
        {
            var data = projeto.ToEntity();

            return Executar(() => _projetoService.Alterar<ProjetoValidator>(data));            
        }

        /// POST /api/projetos
        /// <summary>
        /// Inclui um novo projeto
        /// </summary>
        /// <remarks>
        /// Exemplo:
        /// 
        ///     POST /api/projetos
        ///     
        /// </remarks>
        /// <returns>OK</returns>
        /// <response code="201">Informa que o projeto foi incluído</response>
        /// <response code="400">Erro ao processar solicitação</response>
        /// <response code="404">Projeto não informado na requisição</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Incluir(NovoProjetoModel projeto)
        {
            if (projeto == null)
                return NotFound();

            var data = projeto.ToEntity();

            return Executar( () => _projetoService.Incluir<ProjetoValidator>(data).Id);
        }

        private ActionResult Executar(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
