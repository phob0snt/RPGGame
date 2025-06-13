using UnityEngine;

[CreateAssetMenu(fileName = "MagicEnemyConfig", menuName = "EntityConfigs/Enemy/MagicEnemyConfig")]
public class MagicEnemyConfig : EnemyConfig
{
    [field: SerializeField] public int MagicDamage { get; private set; }
}