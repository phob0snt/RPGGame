using System.Linq;
using UnityEngine;
using Zenject;

public class GlobalStateMachine : ContextStateMachine<IGlobalState>, IGlobalStateMachine
{
    public GlobalStateMachine(DiContainer container) : base(container) { }

    public override void Initialize()
    {
        _states.Add(_container.Resolve<BootState>());
        _states.Add(_container.Resolve<GameLoadState>());
        _states.Add(_container.Resolve<MenuState>());
        _states.Add(_container.Resolve<GameplayState>());

        foreach (var state in _states)
        {
            state.SetStateMachine(this);
        }

        if (_currentState == null)
        {
            SwitchState<BootState>();
        }
    }
}
