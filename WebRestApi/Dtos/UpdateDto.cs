using System.ComponentModel.DataAnnotations;

namespace WebRestApi.Dtos
{
    public record UpdateDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1,10000)]
        public decimal Price { get; init; }
    }
}
