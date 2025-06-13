public interface IGlobalState : IContextState
{
    public void SetStateMachine(IContextStateMachine<IGlobalState> machine);
}
