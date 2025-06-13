using R3;
using System;
using System.Collections.Generic;

public class GameEvent
{

}

public static class EventManager
{
    private static readonly Dictionary<Type, object> _subjects = new();

    public static Observable<T> Recieve<T>() where T : GameEvent
    {
        if (!_subjects.TryGetValue(typeof(T), out var subject))
        {
            subject = new Subject<T>();
            _subjects[typeof(T)] = subject;
        }

        return (Subject<T>)subject;
    }

    public static void Broadcast<T>(T gameEvent) where T : GameEvent
    {
        if (_subjects.TryGetValue(typeof(T), out var subject))
            ((Subject<T>)subject).OnNext(gameEvent);
    }

    public static void Clear()
    {
        _subjects.Clear();
    }
}