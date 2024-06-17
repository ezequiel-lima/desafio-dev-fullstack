using DesafioDevFullstack.Domain.Entities;
using DesafioDevFullstack.Domain.Validators;
using FluentAssertions;

namespace DesafioDevFullstack.Tests.Domain.Entities
{
    public class EnderecoTest
    {
        private readonly EnderecoValidator _validador;

        public EnderecoTest()
        {
            _validador = new EnderecoValidator();
        }

        [Fact]
        public void Deve_Ter_Erro_Quando_Cep_Esta_Vazio()
        {
            var endereco = new Endereco("", "Estado", "Cidade", "Bairro", "Rua", "Numero");

            var resultado = _validador.Validate(endereco);

            resultado.Errors.Should().Contain(x => x.PropertyName == "Cep" && x.ErrorMessage == "CEP é obrigatório.");
        }

        [Fact]
        public void Deve_Ter_Erro_Quando_Cep_Esta_Invalido()
        {
            var endereco = new Endereco("12345", "Estado", "Cidade", "Bairro", "Rua", "Numero");

            var resultado = _validador.Validate(endereco);

            resultado.Errors.Should().Contain(x => x.PropertyName == "Cep" && x.ErrorMessage == "CEP deve conter 8 números");
        }

        [Fact]
        public void Deve_Passar_Quando_Cep_Esta_Valido()
        {
            var endereco = new Endereco("12345678", "Estado", "Cidade", "Bairro", "Rua", "Numero");

            var resultado = _validador.Validate(endereco);

            resultado.Errors.Should().BeEmpty();
        }
    }
}
