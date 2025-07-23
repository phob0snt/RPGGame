using System;
using R3;

public class BossSpawner : EnemySpawner
{
    public override event Action OnSpawnTick;
    private void OnEnable()
    {
        EventManager.Recieve<BossSpawnEvent>().Subscribe((e) => OnSpawnTick?.Invoke());
    }

    protected override void Update()
    {
    }
}