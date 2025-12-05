using System;
using Core;

namespace Tabs.State
{
    public class MainTabState : AbstractTabState<TabsStateManager>
    {
        public event Action AttackClicked;
        public override EMenuState StateType => EMenuState.Main;

        public void OnAttackClicked()
        {
            AttackClicked?.Invoke();
        }
    }
}
