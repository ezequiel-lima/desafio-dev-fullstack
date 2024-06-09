using DesafioDevFullstack.API.Controllers.V2;
using DesafioDevFullstack.Application.Services.Internal.Interfaces;
using DesafioDevFullstack.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DesafioDevFullstack.Tests.API.Controllers.V2
{
    public class EnderecoControllerTest
    {
        private readonly Mock<IGenericService<Endereco>> _mockServico;
        private readonly EnderecoController _controlador;

        public EnderecoControllerTest()
        {
            _mockServico = new Mock<IGenericService<Endereco>>();
            _controlador = new EnderecoController(_mockServico.Object);
        }

        [Fact]
        public async Task PostEnderecoAsync_Deve_Retornar_BadRequest_Quando_Validacao_Falha()
        {
            // Arrange
            var endereco = new Endereco("", "Estado", "Cidade", "Bairro", "Rua", "Numero");
            var validationResult = endereco.Validate();

            // Act
            var resultado = await _controlador.PostEnderecoAsync(endereco);

            // Assert
            resultado.Should().BeOfType<BadRequestObjectResult>();
            var badRequestResult = resultado as BadRequestObjectResult;
            badRequestResult.Value.Should().BeEquivalentTo(validationResult.Errors);
        }

        [Fact]
        public async Task PostEnderecoAsync_Deve_Retornar_Ok_Quando_Validacao_Passa()
        {
            // Arrange
            var endereco = new Endereco("12345678", "Estado", "Cidade", "Bairro", "Rua", "Numero");

            _mockServico.Setup(s => s.AddAsync(It.IsAny<Endereco>())).Returns(Task.CompletedTask);

            // Act
            var resultado = await _controlador.PostEnderecoAsync(endereco);

            // Assert
            resultado.Should().BeOfType<OkObjectResult>();
            var okResult = resultado as OkObjectResult;
            okResult.Value.Should().Be(endereco);
            _mockServico.Verify(s => s.AddAsync(endereco), Times.Once);
        }
    }
}
