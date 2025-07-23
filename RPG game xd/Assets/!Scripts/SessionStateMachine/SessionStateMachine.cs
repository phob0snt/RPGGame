using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class SessionStateMachine : ContextStateMachine<ISessionState>, ISessionStateMachine, IDisposable
{
    public SessionStateMachine(DiContainer container) : base(container) { }

    public override void Initialize()
    {
        _states.Add(_container.Resolve<InitializeState>());
        _states.Add(_container.Resolve<FreeState>());

        foreach (var state in _states)
        {
            state.SetStateMachine(this);
        }

        if (_currentState == null)
        {
            SwitchState<InitializeState>();
        }
    }

    public void Dispose()
    {
        Debug.Log("DISPOSE STATE MACHINE");
        _currentState?.OnExit();
        _states.OfType<FreeState>().FirstOrDefault()?.Dispose();
    }
}
