using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [Inject] private readonly IEntitiesHandler _entitiesHandler;
    public virtual event Action OnSpawnTick;
    public string EnemyAddressablesPath => _enemyAddressablesPath;
    [SerializeField] private string _enemyAddressablesPath;
    [SerializeField] private float _squareRadius = 10f;
    [SerializeField] private float _spawnDelaySeconds = 10f;
    private float _lastSpawnTime;

    private void Awake()
    {
        _entitiesHandler.HandleSpawner(this);
    }

    protected virtual void Update()
    {
        _lastSpawnTime += Time.deltaTime;
        if (_lastSpawnTime >= _spawnDelaySeconds)
        {
            _lastSpawnTime = 0f;
            OnSpawnTick?.Invoke();
        }
    }

    public Vector3 GetSpawnPoint()
    {
        for (int i = 0; i < 30; i++)
        {
            float x = UnityEngine.Random.Range(-_squareRadius, _squareRadius);
            float z = UnityEngine.Random.Range(-_squareRadius, _squareRadius);
            Vector3 candidate = transform.position + new Vector3(x, 10f, z);

            if (NavMesh.SamplePosition(candidate, out NavMeshHit hit, 20f, NavMesh.AllAreas))
            {
                Vector3 groundPos = hit.position;

                if (!Physics.CheckBox(groundPos + Vector3.up * 0.5f, Vector3.one * 0.5f))
                {
                    return groundPos;
                }
            }
        }
        Debug.LogWarning("Failed to find a valid spawn point after 30 attempts, using spawner position.");
        return transform.position;
    }
}