using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private MeleeEnemyConfig _config;
    [SerializeField] private EnemyUI _enemyUI;
    private MeleeComponent _meleeComponent;

    private void Awake()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();
        _healthComponent = GetComponent<Health>();
        _healthComponent.OnValueChanged += _enemyUI.SetHp;
        _healthComponent.Initialize(_config.HP);
        _meleeComponent = GetComponent<MeleeComponent>();
        _meleeComponent.Initialize(_config.SwordDamage);
    }
}