using System;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : BaseGlobalState
{
    private IDisposable _sub;

    public async override void OnEnter()
    {
        await SceneManager.LoadSceneAsync("MainMenu");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _sub = EventManager.Recieve<LoadSceneEvent>().Subscribe(Play);
    }

    public override void OnExit()
    {
        _sub?.Dispose();
    }

    private void Play(LoadSceneEvent _)
    {
        _stateMachine.SwitchState<GameLoadState>();
    }
}
