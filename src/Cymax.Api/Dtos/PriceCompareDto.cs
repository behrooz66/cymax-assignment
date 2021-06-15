namespace Cymax.Api.Dtos
{
    public record PriceCompareDto
    {
        public string Sender { get; init; }
        public string Receiver { get; init; }
        public double Width { get; init; }
        public double Length { get; init; }
        public double Height { get; init; }
    }
}