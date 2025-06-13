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
        _sword.Disable();
    }


    public void SetElement(MagicElement element)
    {
        _sword.SetElement(element);
    }
    
    private void OnEnable()
    {
        _attackStartedSubscription = EventManager.Recieve<AttackStartedEvent>().Subscribe((e) =>
        {
            if (e.SenderID != GetComponentInParent<Entity>().ID)
                return;
            _sword.Enable();
            _sword.PlayEffects();
        });
        _attackEndedSubscription = EventManager.Recieve<AttackEndedEvent>().Subscribe((e) =>
        {
            if (e.SenderID != GetComponentInParent<Entity>().ID)
                return;
            _sword.Disable();
        });
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
        Collider[] hitColliders = Physics.OverlapBox(_attackCollider.bounds.center, _attackCollider.bounds.extents, Quaternion.identity);
        foreach (Collider collider in hitColliders)
        {
            Debug.Log(collider.gameObject.name + " was hit by melee attack");
        }
        Collider component = hitColliders
            .FirstOrDefault(c => c.TryGetComponent(out Health hp) && hp.GetComponent<IEntity>() != GetComponent<IEntity>());
            
        if (component == null) return;

        Health health = component.GetComponent<Health>();
        
        health?.TakeDamage(_damage);
    }
}
