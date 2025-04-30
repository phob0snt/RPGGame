using System;
using UnityEngine;

public class Health : EntityComponent
{
    public event Action<int, int> OnValueChanged;
    public bool IsPlayerComponent { get; private set; }
    public int Value { get; private set; }
    public int MaxValue { get; private set; }

    public void Initialize(int value)
    {
        MaxValue = value;
        Value = value;
        OnValueChanged?.Invoke(Value, MaxValue);
        if (GetComponent<Player>() != null) IsPlayerComponent = true;
        if (IsPlayerComponent) EventManager.Broadcast(new PlayerStatsChangedEvent() { CurrentHp = Value, MaxHp = MaxValue} );
    }
    
    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " took " + damage + " damage!" + "Previous health: " + Value);
        Value -= damage;
        OnValueChanged?.Invoke(Value, MaxValue);
        if (IsPlayerComponent) EventManager.Broadcast(new PlayerStatsChangedEvent() { CurrentHp = Value, MaxHp = MaxValue} );
        if (Value <= 0)
        {
            Die();
            Value = 0;
        }
    }

    private void Die()
    {
        Debug.Log("I'm dead! " + gameObject.name);
        Destroy(gameObject);
    }
}
