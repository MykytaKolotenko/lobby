using System;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ButtonView : MonoBehaviour
    {
        [SerializeField] private Button button;
        public event Action ButtonClicked;

        public bool Interactable
        {
            get => button.interactable;
            set => button.interactable = value;
        }

        public void OnButtonClicked()
        {
            if (!Interactable) return;

            ButtonClicked?.Invoke();
        }
    }
}
