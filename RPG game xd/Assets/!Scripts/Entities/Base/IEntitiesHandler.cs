using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEntitiesHandler
{
    List<IEnemy> GetEnemies();
    void ConfigurePlayer(PlayerData data);
    Task ConfigureEnemies(List<EnemyData> data);
    void HandleSpawner(EnemySpawner spawner);
}