using System.Collections.Generic;
using Storage.Character.Data;
using Storage.Item;
using TMPro;
using UnityEngine;

namespace View
{
    public class InventoryView : MonoBehaviour, ICharacterParamsView
    {
        public RectTransform inventoryParent;
        public List<EquippedItemsPos> equippedItemsPos;

        [SerializeField] private TextMeshProUGUI dmgLabel;
        [SerializeField] private TextMeshProUGUI armorLabel;
        [SerializeField] private TextMeshProUGUI hpLabel;

        public RectTransform GetPosByType(EItemType type)
        {
            return equippedItemsPos.Find(pos => pos.Type == type).Parent;
        }

        public void UpdateParams(CharacterParams param)
        {
            dmgLabel.text = param.Damage.ToString();
            armorLabel.text = param.Armor.ToString();
            hpLabel.text = param.Health.ToString();
        }
    }
}