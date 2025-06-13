using UnityEngine;

public class BossEnemy : Enemy
{
    public override string AddressablesPath => _path;
    [SerializeField] private string _path;
    [SerializeField] private BossEnemyConfig _config;
    [SerializeField] private EnemyUI _enemyUI;
    private bool _isMagicAttacking = false;
    private MeleeComponent _meleeComponent;
    private MagicComponent _magicComponent;
    private MagicElementComponent _magicElementComponent;
    private MagicElement _currentElement;

    public override void Initialize()
    {
        base.Initialize();
        _runawayHpThreshold = _config.RunawayThreshold;
        _healthComponent.OnValueChanged += _enemyUI.SetHp;
        _healthComponent.OnValueChanged += (_, _) => _isPeaceful = false;
        _healthComponent.Initialize(_config.HP);
        _meleeComponent = GetComponent<MeleeComponent>();
        _magicElementComponent = GetComponent<MagicElementComponent>();
        _meleeComponent.Initialize(_config.SwordDamage);
        _magicComponent = GetComponent<MagicComponent>();
        _magicComponent.Initialize(_config.MagicDamage);
    }

    protected override void SetupStateMachine()
    {
        base.SetupStateMachine();

        MagicAttackEnemyState magicAttackEnemyState = new(_animator, this);
        _stateMachine.AddTransition(_idleEnemyState, magicAttackEnemyState, new FuncPredicate(() => _isMagicAttacking));
        _stateMachine.AddTransition(magicAttackEnemyState, _idleEnemyState, new FuncPredicate(() => !_isMagicAttacking));
    }

    public override void CheckTargetDistance()
    {
        base.CheckTargetDistance();

        if (_targetDistance < _config.AttackRange && !_isAttacking && !_isPeaceful)
        {
            _isWalking = false;
            if (WillChangeElement) ChangeElement();
            _ = WillDoMagic ? (_isMagicAttacking = true) : (_isAttacking = true);
        }
    }

    private void ChangeElement()
    {
        _currentElement = _magicElementComponent.GetRandomElement();
        _meleeComponent.SetElement(_currentElement);
        _magicComponent.SetElement(_currentElement);
    }

    private bool WillDoMagic => Random.Range(0, 6) > 3;
    private bool WillChangeElement => Random.Range(0, 6) > 3;

    public void CompleteMeleeAttack()
    {
        if (_isAttacking)
        {
            _isAttacking = false;
            AttackEndedEvent attackEndedEvent = new() { SenderID = ID };
            EventManager.Broadcast(attackEndedEvent);
        }
    }
    
    public void CompleteMagicAttack()
    {
        if (_isMagicAttacking)
        {
            _isMagicAttacking = false;
            MagicEndedEvent magicEndedEvent = new() { SenderID = ID };
            EventManager.Broadcast(magicEndedEvent);
        }
    }
}