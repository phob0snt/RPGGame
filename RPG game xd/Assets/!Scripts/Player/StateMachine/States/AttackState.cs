using UnityEngine;

public class AttackState : BasePlayerState
{
    public AttackState(PlayerController player, Animator animator) : base(player, animator)
    {
    }
    
    public override void Enter()
    {
        AttackStartedEvent evt = new AttackStartedEvent
        {
            SenderID = _playerController.GetPlayer().ID
        };
  
        EventManager.Broadcast(evt);
        _animator.CrossFade("MeleeAttack_OneHanded", 0.1f);
    }
}
