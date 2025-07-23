using UnityEngine;

public class RunEnemyState : EnemyState
{
    public RunEnemyState(Animator animator, Enemy enemy) : base(animator, enemy)
    {
    }

    public override void Enter()
    {
        _animator.CrossFade("Run", CROSSFADE_TIME);
    }

    public override void Update()
    {
        _enemy.FollowPlayer();
        _enemy.CheckTargetDistance();
    }
}