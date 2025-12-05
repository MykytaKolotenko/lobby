using TMPro;
using UnityEngine;

namespace View
{
    public class NumericLabelView : MonoBehaviour, INumericLabel
    {
        [SerializeField] private TextMeshProUGUI label;

        public void SetCurrency(int currency)
        {
            label.text = currency.ToString();
        }
    }
}
