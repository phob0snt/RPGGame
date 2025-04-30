using System.Collections.Generic;
using System;
using Zenject;
using System.Linq;

public abstract class ContextStateMachine<T> : IInitializable, IContextStateMachine<T> where T : IContextState
{
    protected readonly DiContainer _container;
    protected readonly List<T> _states = new();
    protected T _currentState;

    public ContextStateMachine(DiContainer container)
    {
        _container = container;
    }

    public abstract void Initialize();

    public virtual void SwitchState<T1>() where T1 : T
    {
        _currentState?.OnExit();
        _currentState = _states.FirstOrDefault(state => state is T1) ?? throw new InvalidOperationException($"State {typeof(T1).Name} not registered");
        _currentState.OnEnter();
    }
}
