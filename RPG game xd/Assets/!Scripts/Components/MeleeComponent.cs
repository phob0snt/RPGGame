using System;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeComponent : EntityComponent
{
    [SerializeField] private Sword _sword;
    private event Action<AttackStartedEvent> _attackStarted;
    private event Action<AttackEndedEvent> _attackEnded;

    private void Awake()
    {
<<<<<<< Updated upstream
        _attackStarted = (e) => _sword.gameObject.SetActive(true);
        _attackEnded = (e) => _sword.gameObject.SetActive(false);
=======
        _damage = damage;
        _sword.Disable();
    }


    public void SetElement(MagicElement element)
    {
        _sword.SetElement(element);
>>>>>>> Stashed changes
    }
    private void OnEnable()
    {
<<<<<<< Updated upstream
        EventManager.AddListener(_attackStarted);
        EventManager.AddListener(_attackEnded);
=======
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
>>>>>>> Stashed changes
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(_attackStarted);
        EventManager.RemoveListener(_attackEnded);
    }

    public void MeleeAttack()
    {
<<<<<<< Updated upstream
        _sword.Attack();
=======
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
>>>>>>> Stashed changes
    }
}
