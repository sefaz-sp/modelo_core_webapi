using Modelo.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Core.Domain.Interfaces
{
    /// <summary>
    /// Interface base para os repositórios
    /// </summary>
    /// <seealso cref="https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686"/>
    /// <typeparam name="TEntity">Entidade que herda clase BaseEntity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Incluir(TEntity obj);
        void Alterar(TEntity obj);
        void Excluir(int id);
        TEntity Consultar(long id);
        IList<TEntity> Listar();
    }
}
