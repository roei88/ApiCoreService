using InfraSkillsPro.Models;
using System.Collections.Generic;

namespace InfraSkillsPro.Services
{
    public interface IItemService
    {
        Item GetItemById(string id);
        IEnumerable<Item> GetAllItems();
        Item CreateItem(Item item);
        void UpdateItem(string id, Item updatedItem);
        void DeleteItem(string id);
    }
}
