namespace Cymax.Api.Dtos
{
    public record Api2RequestDto
    {
        public string Consignee { get; init; }
        public string Consignor { get; init; }
        public double[] Cartons { get; init; }
    }
}