using System;

namespace Storage.User
{
    public class UserStorage : IUserStorage
    {
        public int Value { get; private set; }

        public event Action<int> OnValueChanged;

        public UserStorage(int currency)
        {
            Value = currency;
        }
    }
}
