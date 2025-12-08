using System;
using Configs;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private ButtonView button;

        public event Action ItemClicked;

        private void OnEnable()
        {
            button.ButtonClicked += OnButtonClick;
        }

        private void OnDisable()
        {
            button.ButtonClicked -= OnButtonClick;
        }

        public void Init(ItemConfig config)
        {
            icon.sprite = config.Icon;
        }

        public void SetParent(RectTransform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        private void OnButtonClick()
        {
            ItemClicked?.Invoke();
        }
    }
}
