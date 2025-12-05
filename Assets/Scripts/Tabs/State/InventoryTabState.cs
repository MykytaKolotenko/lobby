using Core;

namespace Tabs.State
{
    public class InventoryTabState : AbstractTabState<TabsStateManager>
    {
        public override EMenuState StateType => EMenuState.Inventory;
    }
}
