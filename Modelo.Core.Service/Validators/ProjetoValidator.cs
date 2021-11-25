using FluentValidation;
using Modelo.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Core.Service.Validators
{
    public class ProjetoValidator : AbstractValidator<ProjetoEntity>
    {
        public ProjetoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo nome é obrigatório")
                .NotNull().WithMessage("O campo nome é obrigatório");
        }
    }
}
