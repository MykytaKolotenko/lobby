using System.Collections.Generic;
using Configs;
using Factory;
using Storage.Character;
using Storage.Character.Data;
using Storage.Item;
using Utils;
using View;

namespace Presenter
{
    public class InventoryPresenter
    {
        private readonly ItemStorage _itemStorage;
        private readonly CharacterStorage _characterStorage;
        private readonly InventoryItemFactory _factory;
        private readonly InventoryView _view;
        private readonly Dictionary<string, List<InventoryItemPresenter>> _inventoryItemPresenters;
        private readonly Dictionary<EItemType, InventoryItemPresenter> _equippedItemPresenters;

        private readonly CharacterParamsPresenter _paramPresenter;

        public InventoryPresenter(
            InventoryView view,
            ItemStorage itemStorage,
            CharacterStorage characterStorage,
            PrefabDatabase prefabDatabase,
            CharacterParamsPresenter paramPresenter
        )
        {
            _view = view;
            _itemStorage = itemStorage;
            _characterStorage = characterStorage;
            _paramPresenter = paramPresenter;

            _factory = new InventoryItemFactory(prefabDatabase.InventoryItemPrefab);
            _inventoryItemPresenters = new Dictionary<string, List<InventoryItemPresenter>>();
            _equippedItemPresenters = new Dictionary<EItemType, InventoryItemPresenter>();

            Init();
        }

        public void Subscribe()
        {
            _itemStorage.InventoryItemAdded += AddItemToInventory;
            _paramPresenter.Subscribe();
        }

        public void Unsubscribe()
        {
            _itemStorage.InventoryItemAdded -= AddItemToInventory;
            _paramPresenter.Unsubscribe();
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

            _paramPresenter.Init();
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

        private void ItemClicked(InventoryItemPresenter presenter)
        {
            if (_equippedItemPresenters.TryGetValue(presenter.ItemType, out InventoryItemPresenter equippedPresenter))
            {
                RemoveEquippedItem(equippedPresenter);
            }

            if (equippedPresenter != presenter)
            {
                EquipItem(presenter);
            }

            CharacterParams newParams = CoreGameUtils.EvaluateParams(_itemStorage.GetEquippedItems(), _characterStorage.BaseParams);

            _characterStorage.UpdateParams(newParams);
        }

        private void RemoveEquippedItem(InventoryItemPresenter presenter)
        {
            _equippedItemPresenters.Remove(presenter.ItemType);

            AddToInventoryDictionary(presenter);

            presenter.SetParent(_view.inventoryParent);

            _itemStorage.RemoveEquippedItem(presenter.ItemType);
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
