using System;
using System.Threading.Tasks;
using R3;
using UnityEngine.SceneManagement;

public class InitializeState : BaseSessionState
{
    private IDisposable _sub;
    public override void OnEnter()
    {
        _sub = EventManager.Recieve<SystemsInitializedEvent>().Subscribe(SwitchToGameplayState);
    }

    public override void OnExit()
    {
        _sub?.Dispose();
    }

    private void SwitchToGameplayState(SystemsInitializedEvent _)
    {
        _stateMachine.SwitchState<FreeState>();
    }
}