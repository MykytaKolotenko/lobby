using Configs;
using DefaultNamespace;
using LobbyState;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private LobbyStateController lobbyStateController;

    [Header("PresenterHost")]
    [SerializeField] private PresenterHost presenterHost;

    [Header("Configs")]
    [SerializeField] public MainConfig mainConfig;

    public GameStorage GameStorage { get; private set; }

    private void Awake()
    {
        GameStorage = new GameStorage(this);
        presenterHost.Init(this);

        lobbyStateController.Init(mainConfig.InitState);
    }

    private void OnEnable()
    {
        presenterHost.Subscribe();
    }

    private void OnDisable()
    {
        presenterHost.Unsubscribe();
    }
}
