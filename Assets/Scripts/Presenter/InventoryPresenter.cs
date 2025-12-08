using System.Collections.Generic;
using Configs;
using Factory;
using Storage.Character;
using Storage.Item;
using View;

namespace Presenter
{
    public class InventoryPresenter
    {
        private readonly ItemStorage _itemStorage;
        private readonly CharacterStorage _characterStorage;
        private readonly InventoryItemFactory _factory;
        private readonly InventoryView _view;
        private readonly PrefabDatabase _prefabDatabase;
        private readonly Dictionary<string, List<InventoryItemPresenter>> _inventoryItemPresenters;
        private readonly Dictionary<EItemType, InventoryItemPresenter> _equippedItemPresenters;

        private readonly CharacterParamsPresenter _paramPresenter;

        public InventoryPresenter(
            InventoryView view,
            ItemStorage itemStorage,
            CharacterStorage characterStorage,
            PrefabDatabase prefabDatabase
        )
        {
            _prefabDatabase = prefabDatabase;
            _view = view;
            _itemStorage = itemStorage;
            _factory = new InventoryItemFactory(prefabDatabase.InventoryItemPrefab);
            _inventoryItemPresenters = new Dictionary<string, List<InventoryItemPresenter>>();
            _equippedItemPresenters = new Dictionary<EItemType, InventoryItemPresenter>();
            _paramPresenter = new CharacterParamsPresenter(_view, characterStorage);

            Init();
        }

        public void Subscribe()
        {
            _itemStorage.InventoryItemAdded += AddItemToInventory;
        }

        public void Unsubscribe()
        {
            _itemStorage.InventoryItemAdded -= AddItemToInventory;
        }

        private void Init()
        {
            foreach (KeyValuePair<string, int> storageInventoryItem in _itemStorage.InventoryItems)
            {
                for (int i = 0; i < storageInventoryItem.Value; i++)
                {
                    AddItemToInventory(storageInventoryItem.Key);
                }
            }
        }

        private void AddItemToInventory(string itemId)
        {
            ItemConfig config = _itemStorage.GetItemById(itemId);

            if (config == null) return;

            InventoryItemPresenter presenter = CreateItemPresenter(config);

            SubscribeToItem(presenter);
        }

        private InventoryItemPresenter CreateItemPresenter(ItemConfig config)
        {
            InventoryItemView view = _factory.Create(config, _view.inventoryParent);
            InventoryItemPresenter presenter = new InventoryItemPresenter(view, config);

            AddToInventoryDictionary(presenter);


            return presenter;
        }

        private void AddToInventoryDictionary(InventoryItemPresenter presenter)
        {
            if (_inventoryItemPresenters.TryGetValue(presenter.ItemId, out List<InventoryItemPresenter> items))
            {
                items.Add(presenter);
            }
            else
            {
                _inventoryItemPresenters[presenter.ItemId] = new List<InventoryItemPresenter> { presenter };
            }
        }

        private void SubscribeToItem(InventoryItemPresenter presenter)
        {
            presenter.Subscribe();
            presenter.ItemClicked += ItemClicked;
        }

        private void UnsubscribeToItem(InventoryItemPresenter presenter)
        {
            presenter.Unsubscribe();
            presenter.ItemClicked -= ItemClicked;
        }

        private void ItemClicked(InventoryItemPresenter presenter)
        {
            if (_equippedItemPresenters.TryGetValue(presenter.ItemType, out InventoryItemPresenter equippedPresenter))
            {
                TryRemoveEquippedItem(equippedPresenter);
            }

            if (equippedPresenter == presenter) return;

            EquipItem(presenter);
        }

        private void TryRemoveEquippedItem(InventoryItemPresenter presenter)
        {
            _equippedItemPresenters.Remove(presenter.ItemType);

            AddToInventoryDictionary(presenter);

            presenter.SetParent(_view.inventoryParent);
        }

        private void EquipItem(InventoryItemPresenter presenter)
        {
            _equippedItemPresenters[presenter.ItemType] = presenter;

            List<InventoryItemPresenter> itemPresenterList = _inventoryItemPresenters[presenter.ItemId];
            itemPresenterList.Remove(presenter);

            presenter.SetParent(_view.GetPosByType(presenter.ItemType));

            _itemStorage.EquipItem(presenter.ItemType, presenter.ItemId);
        }
    }
}
