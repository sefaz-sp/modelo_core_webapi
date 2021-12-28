using FluentValidation;
using Modelo.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Core.Domain.Interfaces
{
    /// <summary>
    /// Interface base para os serviços
    /// </summary>
    /// <seealso cref="https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686"/>
    /// <typeparam name="TEntity">Entidade que herda clase BaseEntity</typeparam>
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Incluir<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void Excluir(int id);
        TEntity Consultar(int id);
        IList<TEntity> Listar();
        TEntity Alterar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
