namespace WebRestApi.Dtos
{
    public record CreateDto
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}
