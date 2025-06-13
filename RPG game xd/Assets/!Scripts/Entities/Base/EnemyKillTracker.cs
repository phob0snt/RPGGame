using System;
using R3;
using UnityEngine;
using Zenject;

public class EnemyKillTracker : IEnemyKillTracker, IInitializable, IDisposable
{
    private readonly IAudioManager _audioManager;
    private int _killCount = 0;
    private IDisposable _killSubscription;

    public EnemyKillTracker(IAudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void Initialize()
    {
        _killSubscription = EventManager.Recieve<EnemyKilledEvent>().Subscribe((e) => RegisterKill());
    }
    
    public void Dispose()
    {
        _killSubscription?.Dispose();
        _killSubscription = null;
    }

    private void RegisterKill()
    {
        _killCount++;
        Debug.Log($"Enemies killed: {_killCount}");
        if (_killCount == 3)
            EventManager.Broadcast(Events.BossSpawnEvent);
        if (_killCount == 5)
            _audioManager.Play(AudioType.WinSound);
    }
}
