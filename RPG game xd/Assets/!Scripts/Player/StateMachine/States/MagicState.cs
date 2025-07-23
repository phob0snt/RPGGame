using UnityEngine;

public class MagicState : BasePlayerState
{
    public MagicState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void Enter()
    {
        MagicStartedEvent evt = new MagicStartedEvent
        {
            SenderID = _playerController.GetPlayer().ID
        };
        EventManager.Broadcast(evt);
        _animator.CrossFade("SpellCast", 0.1f);
    }
}