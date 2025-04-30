using System;
using System.Linq;
using R3;
using UnityEngine;

public class MeleeComponent : EntityComponent
{
    [SerializeField] private Sword _sword;
    [SerializeField] private BoxCollider _attackCollider;
    private IDisposable _attackStartedSubscription;
    private IDisposable _attackEndedSubscription;
    private int _damage;

    public void Initialize(int damage)
    {
        _damage = damage;
    }
    
    private void OnEnable()
    {
        _attackStartedSubscription = EventManager.Recieve<AttackStartedEvent>().Subscribe((e) => _sword.Enable());
        _attackEndedSubscription = EventManager.Recieve<AttackEndedEvent>().Subscribe((e) => _sword.Disable());
    }

    private void OnDisable()
    {
        _attackStartedSubscription?.Dispose();
        _attackEndedSubscription?.Dispose();
        _attackStartedSubscription = null;
        _attackEndedSubscription = null;
    }

    public void MeleeAttack()
    {
        Collider component = Physics.OverlapBox(_attackCollider.bounds.center, _attackCollider.bounds.extents, Quaternion.identity)
            .FirstOrDefault(c => c.TryGetComponent(out Health hp) && hp.GetComponent<IEntity>() != GetComponent<IEntity>());
            
        if (component == null) return;

        Health health = component.GetComponent<Health>();
        
        health?.TakeDamage(_damage);
    }
}
