using Configs;
using Presenter;
using Storage.Character;
using Storage.User;
using UnityEngine;
using UnityEngine.Serialization;
using View;

public class PresenterHost : MonoBehaviour
{
    [SerializeField] private NumericLabelView currencyView;
    [FormerlySerializedAs("attackButtonView")] [SerializeField] private ButtonView buttonView;

    private GameRoot _gameRoot;

    public NumericPresenter CurrencyPresenter { get; private set; }
    public AttackButtonPresenter AttackButtonPresenter { get; private set; }

    public void Init(GameRoot gameRoot)
    {
        _gameRoot = gameRoot;

        Register();
    }

    private void Register()
    {
        CurrencyPresenter = new NumericPresenter(UserStorage, currencyView);
        AttackButtonPresenter = new AttackButtonPresenter(buttonView, UserStorage, CharacterStorage, MainConfig.paramsConverterConfig);
    }

    public void Subscribe()
    {
        CurrencyPresenter.Subscribe();
        AttackButtonPresenter.Subscribe();
    }

    public void Unsubscribe()
    {
        CurrencyPresenter.Unsubscribe();
        AttackButtonPresenter.Unsubscribe();
    }

    private UserStorage UserStorage => _gameRoot.GameStorage.UserStorage;
    private CharacterStorage CharacterStorage => _gameRoot.GameStorage.CharacterStorage;
    private MainConfig MainConfig => _gameRoot.mainConfig;
}