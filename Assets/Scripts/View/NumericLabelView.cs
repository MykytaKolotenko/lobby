using TMPro;
using UnityEngine;

namespace View
{
    public class NumericLabelView : MonoBehaviour, INumericLabelView
    {
        [SerializeField] private TextMeshProUGUI label;

        public void SetCurrency(int currency)
        {
            label.text = currency.ToString();
        }
    }
}
