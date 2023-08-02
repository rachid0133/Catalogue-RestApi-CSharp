using Microsoft.AspNetCore.Mvc;
using WebRestApi.Dtos;
using WebRestApi.Entities;
using WebRestApi.Repositories;

namespace WebRestApi.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;

        public ItemsController(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = _itemsRepository.GetItems().Select(item => item.asDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _itemsRepository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item.asDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTime.Now
            };

            _itemsRepository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.asDto());

        }

    }
}
