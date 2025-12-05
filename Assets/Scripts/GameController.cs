using Configs;
using Currency;
using MenuButton;
using Storage.Character;
using Storage.User;
using Tabs;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private MenuButtonStateManager menuButtonStateManager;
    [SerializeField] private TabsStateManager tabsStateManager;

    [Header("Presenters")]
    [SerializeField] private CurrencyPresenter currencyPresenter;

    [FormerlySerializedAs("config")]
    [FormerlySerializedAs("configDatabase")]
    [Header("Configs")]
    [SerializeField] private MainConfig mainConfig;

    private CharacterStorage _characterStorage;
    private UserStorage _userStorage;

    private void Awake()
    {
        _characterStorage = new CharacterStorage(mainConfig.characterStatsConfig);
        _userStorage = new UserStorage(mainConfig.Currency);

        currencyPresenter.Init(_userStorage);
        tabsStateManager.Init(_characterStorage);
    }

    private void Start()
    {
        tabsStateManager.SetState(mainConfig.InitState);
        menuButtonStateManager.SetState(mainConfig.InitState);
    }

    private void OnEnable()
    {
        menuButtonStateManager.OnStateChanged += StateChanged;
    }

    private void OnDisable()
    {
        menuButtonStateManager.OnStateChanged -= StateChanged;
    }

    private void StateChanged(EMenuState state)
    {
        tabsStateManager.SetState(state);
    }
}
