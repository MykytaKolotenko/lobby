using Core;

namespace Tabs.State
{
    public abstract class AbstractTabState<T> : AbstractLobbyState<T>
    {
        public override void Init(T menuButtonStateManager)
        {
            gameObject.SetActive(false);
        }

        public override void OnStateEnter()
        {
            gameObject.SetActive(true);
        }

        public override void OnStateExit()
        {
            gameObject.SetActive(false);
        }
    }
}
