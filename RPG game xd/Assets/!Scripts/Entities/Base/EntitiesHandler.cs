using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EntitiesHandler : IEntitiesHandler, IAsyncInitializable
{
    [Inject] private readonly Player _player;
    private readonly List<IEnemy> _enemies = new();
    private IEnemyFactory _factory;

    public EntitiesHandler(IEnemyFactory factory, IAssetLoader assetLoader)
    {
        _factory = factory;
    }

    public async Task InitializeAsync()
    {
        Debug.Log("INITT");
        await Task.Delay(5000);
        await CreateMeleeEnemy(AddressablesPaths.MELEE_ENEMY);
        Debug.Log("created)");
    }

    public List<IEnemy> GetEnemies()
    {
        return _enemies;
    }

    // public async void CreateEnemy()
    // {
    //     IEnemy enemy = _factory.CreateEnemy();
    //     _enemies.Add(enemy);
    //     Vector3 randPos = new Vector3(Random.Range(-30, 30), 20, Random.Range(-30, 30)) + Player.Transform.position;
    //     NavMeshHit hit;
    //     while (!NavMesh.SamplePosition(randPos, out hit, 10, NavMesh.AllAreas))
    //     {
    //         Debug.Log("UNLUCK");
    //         randPos = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30)) + Player.Transform.position;
    //     }
    //     enemy.SetPosition(hit.position);
    //     await Task.Delay(1000);
    //     enemy.SetTarget(Player.Transform);
    // }

    public async Task<IEnemy> CreateMeleeEnemy(string addressablesPath)
    {
        IEnemy enemy = await _factory.CreateEnemy<MeleeEnemy>(addressablesPath);
        _enemies.Add(enemy);
        Vector3 randPos = new Vector3(Random.Range(-20, 20), 20, Random.Range(-20, 20)) + Player.Transform.position;
        NavMeshHit hit;
        while (!NavMesh.SamplePosition(randPos, out hit, 10, NavMesh.AllAreas))
        {
            randPos = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)) + Player.Transform.position;
        }
        enemy.SetPosition(hit.position);
        await Task.Delay(1000);
        enemy.SetTarget(Player.Transform);
        return enemy;
    }

    public void ConfigurePlayer(PlayerData data)
    {
        _player.Configure(data);
    }

    public async Task ConfigureEnemies(List<EnemyData> data)
    {
        foreach (var enemy in data)
        {
            IEnemy enmy = await CreateMeleeEnemy(AddressablesPaths.MELEE_ENEMY);
            enmy.SetPosition(new Vector3(enemy.Transform.xPos, enemy.Transform.yPos, enemy.Transform.zPos));
        }
    }
}

public static class AddressablesPaths
{
    public const string PLAYER_CONFIG = "PlayerConfig";
    public const string MELEE_ENEMY_CONFIG = "MeleeEnemyConfig";
    public const string MELEE_ENEMY = "MeleeEnemy";
    public const string RANGED_ENEMY_CONFIG = "RangedEnemyConfig";
}