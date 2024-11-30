using InfraSkillsPro.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace InfraSkillsPro.Services
{
    public class ItemService : IItemService
    {
        private readonly IMongoCollection<Item> _itemsCollection;

        public ItemService(IMongoDatabase database)
        {
            _itemsCollection = database.GetCollection<Item>("Items");
        }

        public Item GetItemById(string id)
        {
            var item = _itemsCollection.Find(i => i.Id == id).FirstOrDefault();
            if (item == null)
            {
                throw new KeyNotFoundException($"Item with id {id} not found.");
            }
            return item;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _itemsCollection.Find(item => true).ToList();
        }

        public Item CreateItem(Item item)
        {
            _itemsCollection.InsertOne(item);
            return item;
        }

        public void UpdateItem(string id, Item updatedItem)
        {
            var result = _itemsCollection.ReplaceOne(item => item.Id == id, updatedItem);
            if (result.MatchedCount == 0)
            {
                throw new KeyNotFoundException($"Item with id {id} not found for update.");
            }
        }

        public void DeleteItem(string id)
        {
            var result = _itemsCollection.DeleteOne(item => item.Id == id);
            if (result.DeletedCount == 0)
            {
                throw new KeyNotFoundException($"Item with id {id} not found for deletion.");
            }
        }
    }
}
