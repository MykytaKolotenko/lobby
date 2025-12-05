using System;

namespace Storage.User
{
    public interface IUserStorage
    {
        public int Currency { get; }

        public event Action<int> OnCurrencyChanged;
    }
}
