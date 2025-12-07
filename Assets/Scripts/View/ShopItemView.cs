using System;
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ShopItemView : MonoBehaviour
    {
        [SerializeField] private Image spriteIcon;
        [SerializeField] private TextMeshProUGUI nameLabel;
        [SerializeField] private TextMeshProUGUI descriptionLabel;
        [SerializeField] private TextMeshProUGUI priceLabel;
        [SerializeField] private TextMeshProUGUI atkLabel;
        [SerializeField] private TextMeshProUGUI defLabel;
        [SerializeField] private TextMeshProUGUI hpLabel;
        [SerializeField] public ButtonView buttonView;

        public string Id { get; private set; }

        public event Action<string> ItemClicked;

        private void OnEnable()
        {
            buttonView.ButtonClicked += OnButtonClicked;
        }

        private void OnDisable()
        {
            buttonView.ButtonClicked -= OnButtonClicked;
        }

        private void OnButtonClicked()
        {
            ItemClicked?.Invoke(Id);
        }

        public void Init(ItemConfig config)
        {
            Id = config.Id;
            UpdateView(config);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        private void UpdateView(ItemConfig config)
        {
            spriteIcon.sprite = config.Icon;
            nameLabel.text = config.Name;
            descriptionLabel.text = config.Description;
            priceLabel.text = config.Price.ToString();
            atkLabel.text = config.Params.Damage.ToString();
            defLabel.text = config.Params.Armor.ToString();
            hpLabel.text = config.Params.Health.ToString();
        }
    }
}
