using DesafioDevFullstack.Shared.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace DesafioDevFullstack.Domain.Entities
{
    public class Endereco : Entity
    {
        protected Endereco() { }

        public Endereco(string cep, string estado, string cidade, string? bairro, string? rua, string? numero)
        {
            Cep = cep;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
        }

        public string Cep { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string? Bairro { get; private set; }
        public string? Rua { get; private set; }
        public string? Numero { get; private set; }

        public ValidationResult Validate()
        {
            return new EnderecoValidator().Validate(this);
        }
    }

    public sealed class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("CEP é obrigatório.")
                .Matches(@"^\d{8}$").WithMessage("CEP deve conter 8 numeros");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("Estado é obrigatório.");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Cidade é obrigatória.");
        }
    }
}
