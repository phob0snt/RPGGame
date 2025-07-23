using System;
using R3;
using Zenject;

public class FreeState : BaseSessionState, IDisposable
{
    [Inject] private readonly IProgressHandler _progressHandler;
    private IDisposable _saveQuitSubscription;
    private IDisposable _quitSubscription;

    public override void OnEnter()
    {
        _saveQuitSubscription = EventManager.Recieve<SaveAndQuitEvent>().Subscribe((e) =>
        {
            _progressHandler.SaveProgress();
        });

        _quitSubscription = EventManager.Recieve<QuitEvent>().Subscribe((e) =>
        {
            _progressHandler.ClearProgress();
        });

    }

    public void Dispose()
    {
        _saveQuitSubscription?.Dispose();
        _quitSubscription?.Dispose();
    }
}