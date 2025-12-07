using System;
using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Storage.Item
{
    public class ItemStorage
    {
        private readonly List<string> _inventoryItems = new List<string>();

        private ItemDatabase _config;

        public event Action<List<string>> InventoryItemsUpdated;

        public List<ItemConfig> Items => _config.items;

        public ItemStorage(ItemDatabase config)
        {
            _config = config;
        }

        public void AddItemToInventory(string itemId)
        {
            _inventoryItems.Add(itemId);

            InventoryItemsUpdated?.Invoke(_inventoryItems);
        }

        public ItemConfig GetItemById(string id)
        {
            return Items.FirstOrDefault(config => config.Id == id);
        }
    }
}
