using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Entity, IEnemy
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    public Transform Target { get; private set;}
    private StateMachine _stateMachine;
    protected Health _healthComponent;
    protected bool _isWalking = false;
    protected bool _isAttacking = false;
    protected bool _isRunaway = false;

    public override void Initialize()
    {
        SetupStateMachine();
        _healthComponent = TryGetComponent<Health>(out var health) ? health : null;
    }

    private void SetupStateMachine()
    {
        _stateMachine = new();
        IdleEnemyState idleEnemyState = new(_animator, this);
        RunEnemyState runEnemyState = new(_animator, this);
        AttackEnemyState attackEnemyState = new(_animator, this);
        RunawayEnemyState runawayEnemyState = new(_animator, this);
        _stateMachine.AddTransition(idleEnemyState, runEnemyState, new FuncPredicate(() => _isWalking && !_isAttacking && !_isRunaway));
        _stateMachine.AddTransition(runEnemyState, idleEnemyState, new FuncPredicate(() => !_isWalking && !_isAttacking && !_isRunaway));
        _stateMachine.AddTransition(runEnemyState, attackEnemyState, new FuncPredicate(() => _isAttacking));
        _stateMachine.AddTransition(attackEnemyState, runEnemyState, new FuncPredicate(() => !_isAttacking && !_isRunaway && _isWalking));
        _stateMachine.AddTransition(runEnemyState, runawayEnemyState, new FuncPredicate(() => _isRunaway));
        _stateMachine.AddTransition(attackEnemyState, runawayEnemyState, new FuncPredicate(() => _isRunaway));
        _stateMachine.AddTransition(runawayEnemyState, idleEnemyState, new FuncPredicate(() => !_isRunaway && !_isWalking && !_isAttacking));
        _stateMachine.SetState(idleEnemyState);
    }
    
    public async void SetTarget(Transform target)
    {
        while (!_agent.isOnNavMesh)
        {
            Debug.Log("))))");
            await Task.Delay(100);
        }
        Target = target;
        //_agent.SetDestination(target.position);
    }

    public void Runaway()
    {
        if (!_isRunaway)
        {
            _isRunaway = true;
            _agent.speed = 10f;
        }

        _agent.SetDestination((Target.position - transform.position).normalized * 10f);
    }

    public void CheckPath()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.3f)
        {
            _isWalking = false;
        }
        else if (Vector3.Distance(transform.position, Target.position) > 0.5f)
        {
            _isWalking = true;
        }
    }

    private void Update()
    {
        UpdateStates();
        _stateMachine?.Update();
        if (Target != null)
        {
            _agent.SetDestination(Target.position);
        }
    }

    private void UpdateStates()
    {
        if (_healthComponent.Value <= 20 && !_isRunaway)
        {
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
