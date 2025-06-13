using System;
using R3;
using UnityEngine;

public class BlockComponent : EntityComponent
{
    [SerializeField] private Shield _shield;
    private IDisposable _blockStarted;
    private IDisposable _blockEnded;
    
    private void OnEnable()
    {
        _blockStarted = EventManager.Recieve<BlockStartedEvent>().Subscribe((e) => _shield.Enable());
        _blockEnded = EventManager.Recieve<BlockEndedEvent>().Subscribe((e) => _shield.Disable());
    }

    private void OnDisable()
    {
        _blockStarted?.Dispose();
        _blockEnded?.Dispose();
        _blockStarted = null;
        _blockEnded = null;
    }

    public void ShieldBlock()
    {
        Debug.Log("Block");
    }
}