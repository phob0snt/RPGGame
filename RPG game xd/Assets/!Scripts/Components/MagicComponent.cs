using System;
using R3;
using UnityEngine;

public class MagicComponent : EntityComponent
{
    [SerializeField] private MagicSpell _spell;
    [SerializeField] private Transform _castRoot;
    private int _damage;
    private IDisposable _magicStarted;
    private IDisposable _magicEnded;
    
    public void Initialize(int damage)
    {
        _damage = damage;
    }

    private void OnEnable()
    {
        _magicStarted = EventManager.Recieve<MagicStartedEvent>().Subscribe((e) => _spell.StartCast());
        _magicEnded = EventManager.Recieve<MagicEndedEvent>().Subscribe((e) => _spell.StopCast());
    }

    private void OnDisable()
    {
        _magicStarted?.Dispose();
        _magicEnded?.Dispose();
        _magicStarted = null;
        _magicEnded = null;
    }

    public void CastSpell()
    {
        _spell.Cast(_castRoot);
    }
}