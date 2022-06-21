using UnityEngine;

public class PlatformSpawnable : Spawnable
{
    private PlatformBehaviour _behaviour;
    private PlatformSpawnableData _spawnData;
    private Spawner _spawner;

    private MeshCollider[][] _meshColliders;
    private MeshFilter _meshFilter;
    private MeshRenderer _meshRenderer;

    private Rigidbody _rigidbody;

    private void Update()
    {
        OnTick(Time.deltaTime);
    }

    public override void Init(SpawnerConfig config)
    {
        PlatformSpawnerConfig spawnerConfig = config as PlatformSpawnerConfig;

        _spawner = spawnerConfig.spawner;

        _meshFilter = gameObject.AddComponent<MeshFilter>();

        _meshFilter.mesh = spawnerConfig.difficulties?[0].platforms?[0].mesh;

        _meshRenderer = gameObject.AddComponent<MeshRenderer>();
        _meshRenderer.material = spawnerConfig.platformMaterial;

        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.isKinematic = true;

        _meshColliders = new MeshCollider[spawnerConfig.difficulties.Length][];

        for (int i = 0; i < spawnerConfig.difficulties.Length; ++i)
        {
            _meshColliders[i] = new MeshCollider[spawnerConfig.difficulties[i].platforms.Length];

            for (int j = 0; j < spawnerConfig.difficulties[i].platforms.Length; ++j)
            {
                _meshColliders[i][j] = gameObject.AddComponent<MeshCollider>();
                _meshColliders[i][j].sharedMesh = spawnerConfig.difficulties[i].platforms[j].mesh;
                _meshColliders[i][j].enabled = false;
            }
        }
    }

    public override void OnSpawn(SpawnableData data)
    {
        _spawnData = data as PlatformSpawnableData;
        _behaviour = _spawnData.behaviour;

        _meshColliders[_spawnData.difficulty][_spawnData.platformIndex].enabled = true;
        _meshFilter.mesh = _meshColliders[_spawnData.difficulty][_spawnData.platformIndex].sharedMesh;

        _behaviour?.OnEnter(_spawner);
    }

    public override void OnDespawn()
    {
        _meshColliders[_spawnData.difficulty][_spawnData.platformIndex].enabled = false;

        _behaviour?.OnExit();
        _behaviour = null;
    }

    public override void OnTick(float deltaTime)
    {
        _behaviour?.OnExecute(deltaTime);
    }
}
