using System;
using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Storage.Item
{
    public class ItemStorage
    {
        private readonly Dictionary<string, int> _inventoryItems = new Dictionary<string, int>();
        private readonly Dictionary<EItemType, string> _equippedItems = new Dictionary<EItemType, string>();

        private ItemDatabase _config;
        public event Action<string> InventoryItemAdded;

        public List<ItemConfig> Items => _config.items;
        public Dictionary<string, int> InventoryItems => _inventoryItems;

        public ItemStorage(ItemDatabase config)
        {
            _config = config;
        }

        public void AddItemToInventory(string itemId)
        {
            if (!_inventoryItems.TryAdd(itemId, 1))
            {
                _inventoryItems[itemId] += 1;
            }

            InventoryItemAdded?.Invoke(itemId);
        }

        public void RemoveItemFromInventory(string itemId)
        {
            if (!_inventoryItems.ContainsKey(itemId)) return;

            _inventoryItems[itemId] -= 1;
        }

        public void EquipItem(EItemType itemType, string itemId)
        {
            if (_equippedItems.TryGetValue(itemType, out string equippedItemId))
            {
                int items = _inventoryItems[equippedItemId];
                _inventoryItems[equippedItemId] = items - 1;
            }

            _equippedItems[itemType] = itemId;
        }

        public void RemoveEquippedItem(EItemType itemType)
        {
            if (!_equippedItems.TryGetValue(itemType, out string equippedItemId)) return;

            AddItemToInventory(equippedItemId);
            _equippedItems.Remove(itemType);
        }

        public ItemConfig GetItemById(string id)
        {
            return Items.FirstOrDefault(config => config.Id == id);
        }
    }
}
