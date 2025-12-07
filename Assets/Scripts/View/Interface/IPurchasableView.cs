using System;

namespace View
{
    public interface IPurchasableView
    {
        public event Action OnPurchaseClicked;
        void UpdatePriceView(bool isAvailable);
    }
}
