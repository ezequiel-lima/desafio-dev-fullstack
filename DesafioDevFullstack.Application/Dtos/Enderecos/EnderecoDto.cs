namespace DesafioDevFullstack.Application.Dtos.Enderecos
{
    public sealed class EnderecoDto
    {
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? Rua { get; set; }
    }
}
