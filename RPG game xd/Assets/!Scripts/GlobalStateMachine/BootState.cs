using UnityEngine.SceneManagement;

public class BootState : BaseGlobalState
{
    public override void OnEnter()
    {
        if (SceneManager.GetActiveScene().name == "mainScene") _stateMachine.SwitchState<GameplayState>();
        else _stateMachine.SwitchState<MenuState>();
    }
}