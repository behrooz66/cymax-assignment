namespace Cymax.Api.Dtos
{
    public record Api1RequestDto
    {
        public string ContactAddress { get; init; }
        public string WarehouseAddress { get; init; }
        public double[] CartonDimensions { get; init; }
    }
}