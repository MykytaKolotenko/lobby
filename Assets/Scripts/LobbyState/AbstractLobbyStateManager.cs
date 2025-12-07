using System.Linq;
using UnityEngine;

namespace Core
{
    public abstract class AbstractLobbyStateManager<T> : MonoBehaviour
    {
        [SerializeField] protected AbstractLobbyState<T>[] states;

        private AbstractLobbyState<T> _currentState;

        public abstract void Init();

        public virtual void SetState(EMenuState state)
        {
            if (_currentState && _currentState.StateType == state) return;

            AbstractLobbyState<T> nextState = GetState(state);

            if (nextState == null)
            {
                Debug.LogError($"State {state} not found");

                return;
            }

            _currentState?.OnStateExit();
            _currentState = nextState;
            _currentState.OnStateEnter();
        }

        private AbstractLobbyState<T> GetState(EMenuState state)
        {
            return states.FirstOrDefault(value => value.StateType == state);
        }
    }
}
