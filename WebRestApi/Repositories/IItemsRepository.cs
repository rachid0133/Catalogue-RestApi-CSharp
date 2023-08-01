using WebRestApi.Entities;

namespace WebRestApi.Repositories
{
    public interface IItemsRepository
    {
        IEnumerable<Item> GetItems();

        Item GetItem(Guid id);
    }
}
