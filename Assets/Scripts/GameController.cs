using Configs;
using Core;
using DefaultNamespace;
using MenuButton;
using Tabs;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private MenuButtonStateManager menuButtonStateManager;
    [SerializeField] private TabsStateManager tabsStateManager;

    [Header("PresenterBase")]
    [SerializeField] private PresenterBase presenterBase;

    [Header("Configs")]
    [SerializeField] public MainConfig mainConfig;

    public StorageBase StorageBase { get; private set; }

    private void Awake()
    {
        StorageBase = new StorageBase(this);
        presenterBase.Init(this);

        presenterBase.Subscribe();
    }

    private void Start()
    {
        tabsStateManager.SetState(mainConfig.InitState);
        menuButtonStateManager.SetState(mainConfig.InitState);
    }

    private void OnDestroy()
    {
        presenterBase.Unsubscribe();
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
