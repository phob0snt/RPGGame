using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EntityConfigs/Enemy/RangedEnemyConfig")]
public class RangedEnemyConfig : EnemyConfig
{
    [field: SerializeField] public int MagicDamage {get; private set;}
}