using UnityEngine;

[CreateAssetMenu(fileName = "BossEnemyConfig", menuName = "EntityConfigs/Enemy/BossEnemyConfig")]
public class BossEnemyConfig : EnemyConfig
{
    [field: SerializeField] public int SwordDamage { get; private set; }
    [field: SerializeField] public int MagicDamage { get; private set; }
}