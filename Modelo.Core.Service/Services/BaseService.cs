using FluentValidation;
using Modelo.Core.Domain.Entities;
using Modelo.Core.Domain.Exceptions;
using Modelo.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Core.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Alterar<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validar(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Alterar(obj);
            return obj;
        }

        public TEntity Consultar(int id) => _baseRepository.Consultar(id);

        public void Excluir(int id) => _baseRepository.Excluir(id);

        public TEntity Incluir<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validar(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Incluir(obj);
            return obj;
        }

        public IList<TEntity> Listar() => _baseRepository.Listar();

        #region Métodos privados

        private void Validar(TEntity obj, AbstractValidator<TEntity> validador)
        {
            if (obj == null)
                throw new RegistroNuloException("Registros não detectados");

            validador.ValidateAndThrow(obj);
        }

        #endregion
    }
}
