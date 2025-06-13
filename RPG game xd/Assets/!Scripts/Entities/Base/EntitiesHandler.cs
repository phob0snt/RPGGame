using R3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Zenject;

public class EntitiesHandler : IEntitiesHandler, IInitializable, IDisposable
{
    [Inject] private readonly Player _player;
    private readonly List<IEnemy> _enemies = new();
    private IEnemyFactory _factory;

    private bool _isPeacefulMode = false;
    private IDisposable _peacefulModeSubscription;

    public EntitiesHandler(IEnemyFactory factory, IAssetLoader assetLoader)
    {
        _factory = factory;
    }

    public void Initialize()
    {
        Debug.Log("INITT");

        _peacefulModeSubscription = EventManager.Recieve<TogglePeacefulEvent>().Subscribe((e) =>
        {
            TogglePeacefulMode();
        });
    }

    public void HandleSpawner(EnemySpawner spawner)
    {
        spawner.OnSpawnTick += () => FireSpawnerEnemyCreation(spawner.EnemyAddressablesPath, spawner.GetSpawnPoint());
    }

    private void FireSpawnerEnemyCreation(string addressablesPath, Vector3 position)
    {
        CreateEnemy(addressablesPath, position).ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError($"Failed to create enemy: {task.Exception}");
            }
        });
    }

    public void Dispose()
    {
        _peacefulModeSubscription?.Dispose();
        _peacefulModeSubscription = null;
        _factory = null;
    }

    public List<IEnemy> GetEnemies()
    {
        return _enemies;
    }

    private void TogglePeacefulMode()
    {
        _isPeacefulMode = !_isPeacefulMode;
        foreach (var enemy in _enemies)
        {
            Debug.Log("Enemy set peaceful");
            enemy.SetPeaceful(_isPeacefulMode);
        }
    }

    public async Task<IEnemy> CreateEnemy(string addressablesPath, Vector3 position)
    {
        IEnemy enemy = await _factory.CreateEnemy<IEnemy>(addressablesPath);
        enemy.SetID(GUID.Generate().ToString());
        enemy.Initialize();
        _enemies.Add(enemy);
        enemy.SetPeaceful(_isPeacefulMode);
        enemy.SetPosition(position);
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
            IEnemy enmy = await CreateEnemy(enemy.AddressablesPath, new Vector3(enemy.Transform.xPos, enemy.Transform.yPos, enemy.Transform.zPos));
        }
    }
}

public static class AddressablesPaths
{
    public const string MELEE_ENEMY = "MeleeEnemy";
    public const string BOSS_ENEMY = "BossEnemy";
    public const string WIN_SOUND = "WinSound";
}
