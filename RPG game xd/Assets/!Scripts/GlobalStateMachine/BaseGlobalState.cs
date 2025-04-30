public abstract class BaseGlobalState : IGlobalState
{
    protected IGlobalStateMachine _stateMachine;
    public void SetStateMachine(IContextStateMachine<IGlobalState> machine) => _stateMachine = (IGlobalStateMachine)machine;
    public virtual void OnEnter() { }

    public virtual void OnUpdate() { }

    public virtual void OnExit() { }
}