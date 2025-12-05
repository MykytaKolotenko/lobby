using UnityEngine;

namespace Abstractions
{
    public abstract class AbstractLobbyState<T> : MonoBehaviour
    {
        public abstract EMenuState StateType { get; }

        protected T Context { get; set; }
        public abstract void Init(T stateManager);

        public abstract void OnStateEnter();

        public abstract void OnStateExit();
    }
}
