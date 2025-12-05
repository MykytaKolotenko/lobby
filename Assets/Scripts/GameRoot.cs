using Configs;
using Core;
using DefaultNamespace;
using MenuButton;
using Tabs;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private MenuButtonStateManager menuButtonStateManager;
    [SerializeField] private TabsStateManager tabsStateManager;

    [Header("PresenterHost")]
    [SerializeField] private PresenterHost presenterHost;

    [Header("Configs")]
    [SerializeField] public MainConfig mainConfig;

    public GameStorage GameStorage { get; private set; }

    private void Awake()
    {
        GameStorage = new GameStorage(this);
        presenterHost.Init(this);

        presenterHost.Subscribe();
    }

    private void Start()
    {
        tabsStateManager.SetState(mainConfig.InitState);
        menuButtonStateManager.SetState(mainConfig.InitState);
    }

    private void OnDestroy()
    {
        presenterHost.Unsubscribe();
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
