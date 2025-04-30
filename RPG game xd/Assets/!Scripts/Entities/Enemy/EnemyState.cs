using UnityEngine;

public abstract class EnemyState : IState
{
    protected Animator _animator;
    protected Enemy _enemy;
    protected const float CROSSFADE_TIME = 0.3f;

    public EnemyState(Animator animator, Enemy enemy)
    {
        _animator = animator;
        _enemy = enemy;
    }
    
    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }
}