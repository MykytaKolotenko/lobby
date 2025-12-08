using Storage.Character;
using View;

namespace Presenter
{
    public class CharacterParamsPresenter
    {
        private ICharacterParamsView _view;
        private ICharacterParams _storage;

        public CharacterParamsPresenter(ICharacterParamsView view, ICharacterParams storage)
        {
            _view = view;
            _storage = storage;
        }

        public void Subscribe()
        {
            _storage.OnParamsChanged += _view.UpdateParams;
        }

        public void Unsubscribe()
        {
            _storage.OnParamsChanged -= _view.UpdateParams;
        }
    }
}
