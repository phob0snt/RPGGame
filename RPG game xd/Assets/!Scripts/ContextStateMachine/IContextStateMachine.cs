public interface IContextStateMachine<T> where T : IContextState
{
    public void SwitchState<T1>() where T1 : T;
}
