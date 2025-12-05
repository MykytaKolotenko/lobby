using Presenter;
using UnityEngine;
using View;

public class PresenterBase : MonoBehaviour
{
    [SerializeField] private NumericLabelView currencyView;

    private GameController _gameController;

    public NumericPresenter CurrencyPresenter { get; private set; }

    public void Init(GameController gameController)
    {
        _gameController = gameController;

        Register();
    }

    private void Register()
    {
        CurrencyPresenter = new NumericPresenter(_gameController.StorageBase.UserStorage, currencyView);
    }

    public void Subscribe()
    {
        CurrencyPresenter.Subscribe();
    }

    public void Unsubscribe()
    {
        CurrencyPresenter.Unsubscribe();
    }
}
