using Core;

namespace LobbyState.Tabs
{
    public class TabsStateManager : AbstractLobbyStateManager<TabsStateManager>
    {
        public override void Init()
        {
            foreach (AbstractLobbyState<TabsStateManager> abstractMenuButtonState in states)
            {
                abstractMenuButtonState.Init(this);
            }
        }
    }
}
