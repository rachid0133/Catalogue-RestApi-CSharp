using System.Runtime.CompilerServices;
using WebRestApi.Dtos;
using WebRestApi.Entities;

namespace WebRestApi
{
    public static class Extensions
    {
        public static ItemDto asDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate,
            };
        }
    }
}
