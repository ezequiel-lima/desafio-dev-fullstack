namespace DesafioDevFullstack.Application.Dtos.Enderecos
{
    public sealed class EnderecoExternoDto
    {
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Service { get; set; }
        public LocationDto Location { get; set; }
    }

    public sealed class LocationDto
    {
        public string Type { get; set; }
        public CoordinatesDto Coordinates { get; set; }
    }

    public sealed class CoordinatesDto
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
