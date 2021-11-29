using Microsoft.Extensions.Configuration;
using Modelo.Core.ADO.Infra.Util;
using Modelo.Core.Domain.Entities;
using Modelo.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Modelo.Core.ADO.Infra
{
    public class ProjetoRepository : IBaseRepository<ProjetoEntity>
    {
        private const string BANCO_DADOS = "DB_APLICACAO_MODELO";
        private const string CONSULTAR = "USP_PROJETOS_SEL";
        private const string INCLUIR = "USP_PROJETOS_INS";
        private const string ALTERAR = "USP_PROJETOS_UPD";
        private readonly IConfiguration _configuration;

        public ProjetoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Alterar(ProjetoEntity obj)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString(BANCO_DADOS)))
            {
                using (var cmd = new SqlCommand(ALTERAR, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cd_projeto", obj.Id));
                    cmd.Parameters.Add(new SqlParameter("@nm_projeto", obj.Nome));
                    cmd.Parameters.Add(new SqlParameter("@ds_projeto", obj.Descricao));

                    var projeto = new ProjetoEntity();
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ProjetoEntity Consultar(long id)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString(BANCO_DADOS)))
            {
                using (var cmd = new SqlCommand(CONSULTAR, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@cd_projeto", id));

                    var projeto = new ProjetoEntity();
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projeto = MapearParaEntidade(reader);
                        }
                    }

                    return projeto;
                }
            }
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(ProjetoEntity obj)
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString(BANCO_DADOS)))
            {
                using (var cmd = new SqlCommand(INCLUIR, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nm_projeto", obj.Nome));
                    cmd.Parameters.Add(new SqlParameter("@ds_projeto", obj.Descricao));

                    var projeto = new ProjetoEntity();
                    conn.Open();
                    obj.Id = cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<ProjetoEntity> Listar()
        {
            using (var conn = new SqlConnection(_configuration.GetConnectionString(BANCO_DADOS)))
            {
                using (var cmd = new SqlCommand(CONSULTAR, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var projetos = new List<ProjetoEntity>();
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            projetos.Add(MapearParaEntidade(reader));
                        }
                    }

                    return projetos;
                }
            }
        }

        private ProjetoEntity MapearParaEntidade(SqlDataReader reader)
        {
            var safeReader = new SafeReader(reader);

            return new ProjetoEntity
            {
                Id = safeReader.Get<Int64>("cd_projeto", Int64.MinValue),
                Descricao = reader["ds_projeto"].ToString(),
                Nome = reader["nm_projeto"].ToString()
            };
        }
    }
}
