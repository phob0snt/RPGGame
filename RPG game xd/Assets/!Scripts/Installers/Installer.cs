using Zenject;
using UnityEngine;

public class Installer : MonoInstaller
{
    [SerializeField] private ViewManager _viewManager;
    [SerializeField] private Player _player;
    public override void InstallBindings()
    {
        Container.Bind<ViewManager>().FromInstance(_viewManager).AsSingle();
        Container.Bind<Player>().FromInstance(_player).AsSingle();
        Container.BindInterfacesTo<EntitiesHandler>().AsSingle();
        Container.BindInterfacesTo<EnemyFactory>().AsSingle();
        Container.BindInterfacesTo<ProgressHandler>().AsSingle();
        Container.BindInterfacesTo<AsyncInitializer>().AsSingle();
        Container.BindInterfacesTo<EnemyKillTracker>().AsSingle();
        
        BindStates();
        Container.BindInterfacesTo<SessionStateMachine>().AsSingle();
    }

    private void BindStates()
    {
        Container.Bind<InitializeState>().AsSingle();
        Container.Bind<FreeState>().AsSingle();
    }
}