using DesafioDevFullstack.Application.Dtos.Enderecos;

namespace DesafioDevFullstack.Application.Services.External.Interfaces
{
    public interface IEnderecoExternoService
    {
        Task<EnderecoDto> GetEnderecoByCepAsync(string cep);
    }
}
