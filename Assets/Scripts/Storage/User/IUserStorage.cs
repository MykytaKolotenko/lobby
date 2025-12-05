using System;

namespace Storage.User
{
    public interface IUserStorage
    {
        public int Value { get; }

        public event Action<int> ValueChanged;
    }
}
