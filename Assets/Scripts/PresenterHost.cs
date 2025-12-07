using Configs;
using Presenter;
using Storage.Character;
using Storage.Item;
using Storage.User;
using UnityEngine;
using View;

public class PresenterHost : MonoBehaviour
{
    [SerializeField] private NumericLabelView currencyView;
    [SerializeField] private ButtonView buttonView;
    [SerializeField] private ShopView shopView;

    private GameRoot _gameRoot;

    public NumericPresenter CurrencyPresenter { get; private set; }
    public AttackButtonPresenter AttackButtonPresenter { get; private set; }
    public ShopPresenter ShopPresenter { get; private set; }

    private UserStorage UserStorage => _gameRoot.GameStorage.UserStorage;
    private CharacterStorage CharacterStorage => _gameRoot.GameStorage.CharacterStorage;
    private MainConfig MainConfig => _gameRoot.mainConfig;
    private ItemStorage ItemStorage => _gameRoot.GameStorage.ItemStorage;

    public void Init(GameRoot gameRoot)
    {
        _gameRoot = gameRoot;

        Register();
    }

    private void Register()
    {
        CurrencyPresenter = new NumericPresenter(currencyView, UserStorage);
        AttackButtonPresenter = new AttackButtonPresenter(buttonView, UserStorage, CharacterStorage, MainConfig.paramsConverterConfig);
        ShopPresenter = new ShopPresenter(shopView, UserStorage, ItemStorage);
    }

    public void Subscribe()
    {
        CurrencyPresenter.Subscribe();
        AttackButtonPresenter.Subscribe();
        ShopPresenter.Subscribe();
    }

    public void Unsubscribe()
    {
        CurrencyPresenter.Unsubscribe();
        AttackButtonPresenter.Unsubscribe();
        ShopPresenter.Unsubscribe();
    }
}
