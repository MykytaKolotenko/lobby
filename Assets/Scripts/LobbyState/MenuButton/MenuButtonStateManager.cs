using System;
using Core;

namespace LobbyState.MenuButton
{
    public class MenuButtonStateManager : AbstractLobbyStateManager<MenuButtonStateManager>
    {
        public event Action<EMenuState> OnStateChanged;

        public override void Init()
        {
            foreach (AbstractLobbyState<MenuButtonStateManager> abstractMenuButtonState in states)
            {
                abstractMenuButtonState.Init(this);
            }
        }

        public override void SetState(EMenuState state)
        {
            base.SetState(state);

            OnStateChanged?.Invoke(state);
        }
    }
}
