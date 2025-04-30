using System;
using R3;
using UnityEngine;

public class GameplayState : BaseGlobalState
{
    private IDisposable _sub;
    public override void OnEnter()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _sub = EventManager.Recieve<SaveAndQuitEvent>().Subscribe((e) =>
        {
            _stateMachine.SwitchState<MenuState>();
        });
    }

    public override void OnExit()
    {
        _sub?.Dispose();
    }
}