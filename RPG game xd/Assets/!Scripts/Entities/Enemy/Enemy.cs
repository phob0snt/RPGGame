using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Entity, IEnemy
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] protected Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    public Transform Target { get; private set; }
    protected StateMachine _stateMachine;
    protected Health _healthComponent;
    protected bool _isPeaceful = false;
    protected float _targetDistance = 999f;
    protected bool _isWalking = false;
    protected bool _isAttacking = false;
    protected bool _isRunaway = false;
    protected int _runawayHpThreshold;

    protected IdleEnemyState _idleEnemyState;

    public override void Initialize()
    {
        SetupStateMachine();
        _healthComponent = TryGetComponent<Health>(out var health) ? health : null;
        _healthComponent.OnValueChanged += CheckDeath;
    }

    protected virtual void SetupStateMachine()
    {
        _stateMachine = new();
        _idleEnemyState = new(_animator, this);
        RunEnemyState runEnemyState = new(_animator, this);
        AttackEnemyState attackEnemyState = new(_animator, this);
        RunawayEnemyState runawayEnemyState = new(_animator, this);
        _stateMachine.AddTransition(_idleEnemyState, runEnemyState, new FuncPredicate(() => _isWalking && !_isAttacking && !_isRunaway));
        _stateMachine.AddTransition(runEnemyState, _idleEnemyState, new FuncPredicate(() => !_isWalking && !_isAttacking && !_isRunaway));
        _stateMachine.AddTransition(runEnemyState, attackEnemyState, new FuncPredicate(() => _isAttacking));
        _stateMachine.AddTransition(_idleEnemyState, attackEnemyState, new FuncPredicate(() => _isAttacking));
        _stateMachine.AddTransition(attackEnemyState, _idleEnemyState, new FuncPredicate(() => !_isAttacking && !_isRunaway && !_isWalking));
        _stateMachine.AddTransition(runEnemyState, runawayEnemyState, new FuncPredicate(() => _isRunaway));
        _stateMachine.AddTransition(_idleEnemyState, runawayEnemyState, new FuncPredicate(() => _isRunaway));
        _stateMachine.AddTransition(attackEnemyState, runawayEnemyState, new FuncPredicate(() => _isRunaway));
        _stateMachine.AddTransition(runawayEnemyState, _idleEnemyState, new FuncPredicate(() => !_isRunaway && !_isWalking && !_isAttacking));
        _stateMachine.SetState(_idleEnemyState);
    }

    public async void SetTarget(Transform target)
    {
        while (!_agent.isOnNavMesh)
        {
            Debug.Log("))))");
            await Task.Delay(100);
        }
        Target = target;
    }

    public void SetPeaceful(bool isPeaceful)
    {
        _isPeaceful = isPeaceful;
        if (isPeaceful)
        {
            _agent.ResetPath();
        }
    }

    public void Runaway()
    {
        Vector3 direction = transform.position - Target.position;
        float distance = direction.magnitude;

        if (distance < 5f)
        {
            Vector3 fleeDirection = direction.normalized;
            Vector3 targetPos = transform.position + fleeDirection * 5f;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(targetPos, out hit, 5f, NavMesh.AllAreas))
            {
                _agent.SetDestination(hit.position);
            }
        }
        //_agent.SetDestination((transform.position - Target.position).normalized * 10f);
    }

    public virtual void CheckTargetDistance()
    {
        Debug.Log(Target);
        if (Target == null || _isPeaceful) return;

        _targetDistance = Vector3.Distance(transform.position, Target.position);

        if (_targetDistance < 10f && !_isWalking)
        {
            _isWalking = true;
        }
        else if (_targetDistance > 10f && _isWalking)
        {
            _isWalking = false;
        }
    }

    public void FollowPlayer()
    {
        if (Target != null && !_isPeaceful)
        {
            _agent.SetDestination(Target.position);
        }
        if (!_agent.pathPending && _agent.remainingDistance < 0.3f)
        {
            _isWalking = false;
        }
    }

    private void Update()
    {
        UpdateStates();
        _stateMachine?.Update();
    }

    private void CheckDeath(int hp, int maxHp)
    {
        if (hp <= 0)
        {
            EventManager.Broadcast(Events.EnemyKilledEvent);
            _healthComponent.OnValueChanged -= CheckDeath;
        }
    }

    private void UpdateStates()
    {
        if (_healthComponent.Value <= _runawayHpThreshold && !_isRunaway)
        {
            _agent.speed = 2f;
            _isRunaway = true;
            _isWalking = false;
            _isAttacking = false;
        }
    }

    public void SetPosition(Vector3 position)
    {
        _agent.Warp(position);
    }
}