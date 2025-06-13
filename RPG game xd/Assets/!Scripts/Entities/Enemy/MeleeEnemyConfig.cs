using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EntityConfigs/Enemy/MeleeEnemyConfig")]
public class MeleeEnemyConfig : EnemyConfig
{
    [field: SerializeField] public int SwordDamage { get; private set; }
}
