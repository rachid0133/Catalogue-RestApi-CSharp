using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Item> GetItems()
        {
            var items = _itemsRepository.GetItems();
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = _itemsRepository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

    }
}
