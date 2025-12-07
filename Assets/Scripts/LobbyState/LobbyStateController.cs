using Core;
using LobbyState.MenuButton;
using LobbyState.Tabs;
using UnityEngine;

namespace LobbyState
{
    public class LobbyStateController : MonoBehaviour
    {
        [SerializeField] private MenuButtonStateManager menuButtonStateManager;
        [SerializeField] private TabsStateManager tabsStateManager;

        private EMenuState _initialState;

        public void Init(EMenuState initialState)
        {
            _initialState = initialState;

            menuButtonStateManager.Init();
            tabsStateManager.Init();
        }

        private void Start()
        {
            menuButtonStateManager.SetState(_initialState);
            tabsStateManager.SetState(_initialState);
        }

        private void OnEnable()
        {
            menuButtonStateManager.OnStateChanged += StateChanged;
        }

        private void OnDisable()
        {
            menuButtonStateManager.OnStateChanged -= StateChanged;
        }

        private void StateChanged(EMenuState state)
        {
            tabsStateManager.SetState(state);
        }
    }
}
