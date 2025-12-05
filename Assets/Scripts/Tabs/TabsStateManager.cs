using System;
using Core;

namespace Tabs
{
    public class TabsStateManager : AbstractLobbyStateManager<TabsStateManager>
    {
        public event Action UpdateGold;

        protected override void InitStates()
        {
            foreach (AbstractLobbyState<TabsStateManager> abstractMenuButtonState in states)
            {
                abstractMenuButtonState.Init(this);
            }
        }
    }
}
