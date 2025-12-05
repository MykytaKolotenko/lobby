using System;

namespace Storage.User
{
    public class UserStorage : IUserStorage
    {
        public int Currency { get; private set; }

        public event Action<int> OnCurrencyChanged;

        public UserStorage(int currency)
        {
            Currency = currency;
        }
    }
}
