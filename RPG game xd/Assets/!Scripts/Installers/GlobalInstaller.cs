using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<InputManager>().AsSingle();
        Container.BindInterfacesTo<AudioManager>().AsSingle();
        Container.BindInterfacesTo<AddressablesAssetLoader>().AsSingle();
        Container.BindInterfacesTo<ProfilesInteractor>().AsSingle();
        Container.BindInterfacesTo<ProfilesRepository>().AsSingle();
        BindStates();
        Container.BindInterfacesTo<GlobalStateMachine>().AsSingle();
    }

    private void BindStates()
    {
        Container.Bind<BootState>().AsSingle();
        Container.Bind<MenuState>().AsSingle();
        Container.Bind<GameLoadState>().AsSingle();
        Container.Bind<GameplayState>().AsSingle();
    }
}