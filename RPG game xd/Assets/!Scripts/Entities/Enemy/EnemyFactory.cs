using System.Threading.Tasks;
using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private readonly IAssetLoader _loader;

    public EnemyFactory(IAssetLoader loader)
    {
        _loader = loader;
    }
    
    public async Task<T> CreateEnemy<T>(string addressablesPath) where T : IEnemy
    {
        GameObject enemy = await _loader.LoadAssetAsync<GameObject>(addressablesPath);
        if (enemy.GetComponent<T>() == null) return default;
        return Object.Instantiate(enemy).GetComponent<T>();
    }
}
