namespace Cymax.Api.Dtos
{
    public record Api3RequestDto
    {
        public string Source { get; init; }
        public string Destination { get; init; }
        public double[] Packages { get; init; }
    }

    public record Api3ResponseDto
    {
        public double Quote { get; init; }
    }
}