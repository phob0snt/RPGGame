using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override string AddressablesPath => _path;
    [SerializeField] private string _path;
    [SerializeField] private MeleeEnemyConfig _config;
    [SerializeField] private EnemyUI _enemyUI;
    private MeleeComponent _meleeComponent;

    public override void Initialize()
    {
        base.Initialize();
        _runawayHpThreshold = _config.RunawayThreshold;
        _healthComponent.OnValueChanged += _enemyUI.SetHp;
        _healthComponent.Initialize(_config.HP);
        _meleeComponent = GetComponent<MeleeComponent>();
        _meleeComponent.Initialize(_config.SwordDamage);
    }

    public override void CheckTargetDistance()
    {
        base.CheckTargetDistance();

        if (_targetDistance < _config.AttackRange && !_isAttacking && !_isPeaceful)
        {
            _isWalking = false;
            _isAttacking = true;
        }
    }

    public void CompleteMeleeAttack()
    {
        if (_isAttacking)
        {
            _isAttacking = false;
            AttackEndedEvent attackEndedEvent = new() { SenderID = ID };
            EventManager.Broadcast(attackEndedEvent);
        }
    }
}