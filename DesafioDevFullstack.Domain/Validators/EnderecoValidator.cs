using DesafioDevFullstack.Domain.Entities;
using FluentValidation;

namespace DesafioDevFullstack.Domain.Validators
{
    public sealed class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("CEP é obrigatório.")
                .Matches(@"^\d{8}$").WithMessage("CEP deve conter 8 números");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("Estado é obrigatório.");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Cidade é obrigatória.");
        }
    }
}
