﻿using System.Diagnostics.Contracts;
using WebRestApi.Entities;

namespace WebRestApi.Repositories
{
    public class InMemItemsRepository: IItemsRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item { Id = Guid.NewGuid(), Name= "Potion", Price= 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name= "Iron Sword", Price= 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name= "Bronzw Sheild", Price= 18, CreatedDate = DateTimeOffset.UtcNow },

        };

        public IEnumerable<Item> GetItems() => _items;

        public Item GetItem(Guid id) => _items.Where(i => i.Id==id).SingleOrDefault();

        public void CreateItem(Item item) => _items.Add(item);

        public void UpdateItem(Item item)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
            _items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var item = _items.FirstOrDefault(i => i.Id==id);

            _items.Remove(item);
        }
    }
}
