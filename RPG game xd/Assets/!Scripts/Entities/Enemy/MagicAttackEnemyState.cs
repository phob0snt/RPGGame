using UnityEngine;

public class MagicAttackEnemyState : EnemyState
{
    public MagicAttackEnemyState(Animator animator, Enemy enemy) : base(animator, enemy) {}

    public override void Enter()
    {
        MagicStartedEvent evt = new ()
        {
            SenderID = _enemy.ID
        };
        EventManager.Broadcast(evt);
        Debug.Log("ENEMY MAGIC ATTACK");
        _animator.CrossFade("MagicAttack", CROSSFADE_TIME);
    }

    public override void Update()
    {
    }
}