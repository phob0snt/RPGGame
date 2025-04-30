public interface ISessionState : IContextState
{
    public void SetStateMachine(IContextStateMachine<ISessionState> machine);
}
