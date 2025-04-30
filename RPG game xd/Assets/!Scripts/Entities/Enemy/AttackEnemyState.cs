using UnityEngine;

public class AttackEnemyState : EnemyState
{
    public AttackEnemyState(Animator animator, Enemy enemy) : base(animator, enemy) {}

    public override void Enter()
    {
        _animator.CrossFade("Attack", CROSSFADE_TIME);
    }

    public override void Update()
    {
    }
}
