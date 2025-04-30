using System.Threading.Tasks;

public interface IEnemyFactory
{
    public Task<T> CreateEnemy<T>(string addressablesPath) where T : IEnemy;
}