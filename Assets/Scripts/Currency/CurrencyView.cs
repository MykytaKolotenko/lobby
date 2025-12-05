using TMPro;
using UnityEngine;

namespace Currency
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;

        public void SetCurrency(int currency)
        {
            label.text = currency.ToString();
        }
    }
}
