using Modelo.Core.Domain.Entities;
using Modelo.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Core.ADO.Infra
{
    public class ProjetoRepository : IBaseRepository<ProjetoEntity>
    {
        public void Alterar(ProjetoEntity obj)
        {
            
        }

        public ProjetoEntity Consultar(long id)
        {
            return Seed().FirstOrDefault(x => x.Id == id);
        }

        public void Excluir(int id)
        {
            
        }

        public void Incluir(ProjetoEntity obj)
        {
            
        }

        public IList<ProjetoEntity> Listar()
        {
            return Seed();
        }

        #region Dados Fake

        private IList<ProjetoEntity> Seed()
        {
            return new List<ProjetoEntity>()
            {
                new ProjetoEntity
                {
                    Id = 1,
                    Nome = "Projeto Teste 1"
                },
                new ProjetoEntity
                {
                    Id = 2,
                    Nome = "Projeto Teste 2",
                    Descricao = "Uma descrição"
                },
                new ProjetoEntity
                {
                    Id = 3,
                    Nome = "Projeto Teste 3",
                    Descricao = "Outra descrição"
                }
            };
        }

        #endregion
    }
}
