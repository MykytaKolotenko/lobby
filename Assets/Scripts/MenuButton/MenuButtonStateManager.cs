using System;
using Core;

namespace MenuButton
{
    public class MenuButtonStateManager : AbstractLobbyStateManager<MenuButtonStateManager>
    {
        public event Action<EMenuState> OnStateChanged;

        protected override void InitStates()
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
