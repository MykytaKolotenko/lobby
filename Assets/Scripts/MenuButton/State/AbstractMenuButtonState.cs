using Core;
using UnityEngine;

namespace MenuButton.State
{
    public abstract class AbstractMenuButtonState : AbstractLobbyState<MenuButtonStateManager>
    {
        [field: SerializeField] protected MenuButtonAnimator MenuButtonAnimator { get; private set; }

        public override void Init(MenuButtonStateManager menuButtonStateManager)
        {
            Context = menuButtonStateManager;
            MenuButtonAnimator.Init();
        }

        public override void OnStateEnter()
        {
            MenuButtonAnimator.SetActive();
        }

        public override void OnStateExit()
        {
            MenuButtonAnimator.SetHide();
        }

        public void OnButtonClick()
        {
            Context.SetState(StateType);
        }
    }
}
