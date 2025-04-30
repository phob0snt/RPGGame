using System;
using R3;
using Zenject;

public class FreeState : BaseSessionState, IDisposable
{
    [Inject] private readonly IProgressHandler _progressHandler;
    private IDisposable _sub;

    public override void OnEnter()
    {
        _sub = EventManager.Recieve<SaveAndQuitEvent>().Subscribe((e) =>
        {
            _progressHandler.SaveProgress();
        });
    }

    public void Dispose()
    {
        _sub?.Dispose();
    }
}