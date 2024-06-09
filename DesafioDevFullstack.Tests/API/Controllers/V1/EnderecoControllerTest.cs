using DesafioDevFullstack.API.Controllers.V1;
using DesafioDevFullstack.Application.Dtos.Enderecos;
using DesafioDevFullstack.Application.Services.External.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DesafioDevFullstack.Tests.API.Controllers.V1
{
    public class EnderecoControllerTest
    {
        private readonly Mock<IEnderecoExternoService> _mockServico;
        private readonly EnderecoController _controlador;

        public EnderecoControllerTest()
        {
            _mockServico = new Mock<IEnderecoExternoService>();
            _controlador = new EnderecoController(_mockServico.Object);
        }

        [Fact]
        public async Task GetEnderecoByCepAsync_Deve_Retornar_NotFound_Quando_Endereco_Nao_Encontrado()
        {
            // Arrange
            var cep = "12345678";
            _mockServico.Setup(s => s.GetEnderecoByCepAsync(cep)).ReturnsAsync((EnderecoDto)null);

            // Act
            var resultado = await _controlador.GetEnderecoByCepAsync(cep);

            // Assert
            resultado.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetEnderecoByCepAsync_Deve_Retornar_Ok_Quando_Endereco_Encontrado()
        {
            // Arrange
            var cep = "12345678";
            var enderecoDto = new EnderecoDto { Cep = cep, Estado = "Estado", Cidade = "Cidade", Bairro = "Bairro", Rua = "Rua" };
            _mockServico.Setup(s => s.GetEnderecoByCepAsync(cep)).ReturnsAsync(enderecoDto);

            // Act
            var resultado = await _controlador.GetEnderecoByCepAsync(cep);

            // Assert
            resultado.Should().BeOfType<OkObjectResult>();
            var okResult = resultado as OkObjectResult;
            okResult.Value.Should().Be(enderecoDto);
        }
    }
}
