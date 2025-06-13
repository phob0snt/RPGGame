public abstract class BaseSessionState : ISessionState
{
    protected ISessionStateMachine _stateMachine;
    public virtual void OnEnter() { }

    public virtual void OnUpdate() { }

    public virtual void OnExit() { }

    public void SetStateMachine(IContextStateMachine<ISessionState> machine) => _stateMachine = (ISessionStateMachine)machine;
}
