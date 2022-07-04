using System.Collections.Generic;
using TinkerLib.DataStructures;
using UnityEngine;

public class PlatformSpawner : Spawner
{
    [SerializeField]
    private PlatformSpawnerConfig _spawnerConfig;

    [SerializeField]
    private int _maxPlatforms = 20;

    private ObjectCache<PlatformSpawnable> _platformCache;

    private Queue<PlatformSpawnableData> _platformQueue;

    private Vector3 _spawnPosition = Vector3.zero;

    private void Awake()
    {
        _spawnerConfig.spawner = this;

        _platformCache = new ObjectCache<PlatformSpawnable>(_maxPlatforms);

        PlatformSpawnable tempSpawn;
        for (int i = 0; i < _maxPlatforms; ++i)
        {
            tempSpawn = new GameObject("Platform " + (i + 1).ToString()).AddComponent<PlatformSpawnable>();
            tempSpawn.transform.parent = transform;
            tempSpawn.gameObject.SetActive(false);
            tempSpawn.Init(_spawnerConfig);

            _platformCache.Add(tempSpawn);
        }
    }

    private void QueueSpawn(SpawnableData data)
    {
        if (data is PlatformSpawnableData)
            _platformQueue.Enqueue(data as PlatformSpawnableData);
    }

    private void SpawnInternal()
    {
        if (_platformQueue.Count > 0)
        {
            if (_platformCache.isEmpty())
                Despawn();

            var data = _platformQueue.Dequeue();
            var platformSpawnable = _platformCache.GetNextInactive();

            platformSpawnable.transform.position = data.positionOffset;
            platformSpawnable.gameObject.SetActive(true);
            platformSpawnable.OnSpawn(data);
        }
    }

    public override void Spawn(SpawnableData data)
    {
        if (_platformCache.isEmpty())
            Despawn();

        var platformSpawnable = _platformCache.GetNextInactive();
        var pData = data as PlatformSpawnableData;

        _spawnPosition += data.positionOffset;
        platformSpawnable.transform.position = _spawnPosition;
        _spawnPosition.z +=
            _spawnerConfig.difficulties[pData.difficulty].platforms[pData.platformIndex].mesh.bounds.size.z;

        pData.behaviour = _spawnerConfig.difficulties[pData.difficulty].platforms[pData.platformIndex].behaviour;

        platformSpawnable.gameObject.SetActive(true);
        platformSpawnable.OnSpawn(data);
    }

    public override void Despawn()
    {
        if (_platformCache.isFull())
            return;

        var platformSpawnable = _platformCache.GetNextActive();

        platformSpawnable.gameObject.SetActive(false);
        platformSpawnable.OnDespawn();
    }

    public override SpawnerConfig GetSpawnerConfig()
    {
        return _spawnerConfig;
    }
}