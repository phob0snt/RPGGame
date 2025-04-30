using UnityEngine;

public class IdleEnemyState : EnemyState
{
    public IdleEnemyState(Animator animator, Enemy enemy) : base(animator, enemy)
    {
    }

    public override void Enter()
    {
        _animator.CrossFade("Idle", CROSSFADE_TIME);
    }

    public override void Update()
    {
        _enemy.CheckPath();
    }
}
