using System;
using Abstractions;
using Storage.Character;

namespace Tabs
{
    public class TabsStateManager : AbstractLobbyStateManager<TabsStateManager>
    {
        public ICharacterParams CharacterStorage { get; private set; }

        public event Action UpdateGold;

        protected override void InitStates()
        {
            foreach (AbstractLobbyState<TabsStateManager> abstractMenuButtonState in states)
            {
                abstractMenuButtonState.Init(this);
            }
        }

        public void Init(ICharacterParams characterStorage)
        {
            CharacterStorage = characterStorage;
        }
    }
}
