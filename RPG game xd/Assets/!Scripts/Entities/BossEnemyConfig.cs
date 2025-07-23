using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EntityConfigs/Enemy/BossEnemyConfig")]
public class BossEnemyConfig : EnemyConfig
{
    [field: SerializeField] public int SwordDamage { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public int MagicDamage { get; private set; }
}