using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProgressHandler : IProgressHandler, IInitializable
{
    private readonly Player _player;
    private readonly IEntitiesHandler _enemiesHandler;
    private readonly IProfilesInteractor _profilesInteractor;
    private GameProfile _activeProfile;

    public ProgressHandler(Player player, IEntitiesHandler handler, IProfilesInteractor profilesInteractor)
    {
        _player = player;
        _enemiesHandler = handler;
        _profilesInteractor = profilesInteractor;
    }

    public void Initialize()
    {
        _activeProfile = _profilesInteractor.ChosenProfile;

        if (_activeProfile == null) return;

        _enemiesHandler.ConfigurePlayer(_activeProfile.PlayerData);
        _enemiesHandler.ConfigureEnemies(_activeProfile.EnemyData);
    }

    public void SaveProgress()
    {
        Debug.Log("HANDLER SAVE PROGRESS");
        _activeProfile.PlayerData = new PlayerData
        {
            Health = _player.GetComponent<Health>().Value,
            Transform = new TransformData(_player.transform)
        };
        Debug.Log("PLAYERHP " + _player.GetComponent<Health>().Value);
        Debug.Log("PLAYER POS " + new TransformData(_player.transform));
        List<EnemyData> enemies = new();
        foreach (var enemy in _enemiesHandler.GetEnemies())
        {
            enemies.Add(new EnemyData() { Transform = new TransformData(enemy.Transform) });
        }
        _activeProfile.EnemyData = enemies;
        _profilesInteractor.SaveGame(_activeProfile);
    }

    public void ClearProgress()
    {
        _profilesInteractor.ClearSave();
    }
}
