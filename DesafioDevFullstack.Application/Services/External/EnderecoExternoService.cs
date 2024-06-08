using AutoMapper;
using DesafioDevFullstack.Application.Dtos.Enderecos;
using DesafioDevFullstack.Application.Services.External.Interfaces;
using System.Text.Json;

namespace DesafioDevFullstack.Application.Services.External
{
    public class EnderecoExternoService : IEnderecoExternoService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public EnderecoExternoService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<EnderecoDto> GetEnderecoByCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://brasilapi.com.br/api/cep/v2/{cep}");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var enderecoExterno = JsonSerializer.Deserialize<EnderecoExternoDto>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var endereco = _mapper.Map<EnderecoDto>(enderecoExterno);
            return endereco;
        }
    }
}
