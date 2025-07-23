using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EntityConfigs/EnemyConfig")]
public class EnemyConfig : EntityConfig
{
<<<<<<< Updated upstream:RPG game xd/Assets/!Scripts/Entities/EnemyConfig.cs
    [field: SerializeField] public int HP {get; private set;}
    [field: SerializeField] public int SwordDamage {get; private set;}
=======
    [field: SerializeField] public int SwordDamage { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
>>>>>>> Stashed changes:RPG game xd/Assets/!Scripts/Entities/Enemy/MeleeEnemyConfig.cs
}
