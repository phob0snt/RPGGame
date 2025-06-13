using System;
using R3;
using UnityEngine;

public class GameplayState : BaseGlobalState
{
    private IDisposable _saveQuitSubscription;
    private IDisposable _quitSubscription;
    public override void OnEnter()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _saveQuitSubscription = EventManager.Recieve<SaveAndQuitEvent>().Subscribe((e) =>
        {
            _stateMachine.SwitchState<MenuState>();
        });

        _quitSubscription = EventManager.Recieve<QuitEvent>().Subscribe((e) =>
        {
            _stateMachine.SwitchState<MenuState>();
        });
    }

    public override void OnExit()
    {
        _saveQuitSubscription?.Dispose();
        _quitSubscription?.Dispose();
    }
}