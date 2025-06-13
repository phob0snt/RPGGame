using UnityEngine;

public abstract class EnemyConfig : EntityConfig
{
    [field: SerializeField] public int HP { get; private set; }
    [field: SerializeField] public int RunawayThreshold {get; private set;}
    [field: SerializeField] public float AttackRange { get; private set; }
}