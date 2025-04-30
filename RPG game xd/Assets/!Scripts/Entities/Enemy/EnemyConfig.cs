using UnityEngine;

public abstract class EnemyConfig : EntityConfig
{
    [field: SerializeField] public int HP {get; private set;}
}