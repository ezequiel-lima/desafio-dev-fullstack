namespace DesafioDevFullstack.Application.Dtos.Enderecos
{
    public sealed class EnderecoDto
    {
        public string Cep { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string? Bairro { get; private set; }
        public string? Rua { get; private set; }
    }
}
