using UnityEngine;

public class AttackEnemyState : EnemyState
{
    public AttackEnemyState(Animator animator, Enemy enemy) : base(animator, enemy) {}

    public override void Enter()
    {
        AttackStartedEvent evt = new ()
        {
            SenderID = _enemy.ID
        };
        EventManager.Broadcast(evt);
        Debug.Log("ENEMY ATTACK");
        _animator.CrossFade("Attack", CROSSFADE_TIME);
    }

    public override void Update()
    {
    }
}