using UnityEngine;

public class RunawayEnemyState : EnemyState
{
    public RunawayEnemyState(Animator animator, Enemy enemy) : base(animator, enemy) {}

    public override void Enter()
    {
        _animator.CrossFade("Run", CROSSFADE_TIME);
        Debug.Log("RunawayEnemyState: Enter");
    }

    public override void Update()
    {
        _enemy.Runaway();
    }
}
