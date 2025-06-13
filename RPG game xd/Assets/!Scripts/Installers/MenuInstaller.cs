using Zenject;
using UnityEngine;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private ViewManager _viewManager;

    public override void InstallBindings()
    {
        Container.Bind<ViewManager>().FromInstance(_viewManager).AsSingle();
    }
}