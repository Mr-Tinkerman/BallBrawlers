using UnityEngine;

[RequireComponent(typeof(PlatformSpawner))]
public class PlatformSpawnerController : MonoBehaviour
{
    private PlatformSpawnerConfig _platformSpawnConfig;

    public Spawner spawner { get => _spawner; }
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _platformSpawnConfig = _spawner.GetSpawnerConfig() as PlatformSpawnerConfig;
    }

#if UNITY_EDITOR
    private void Update()
    {
        // Test if spawning works
        if (Input.GetKeyDown(KeyCode.RightBracket))
            Spawn();
        if (Input.GetKeyDown(KeyCode.LeftBracket))
            Despawn();
    }
#endif

    private void Spawn()
    {
        // TODO: randomize spawned platform
        int diff = TinkerLib.Random.WeightedRandom(_platformSpawnConfig.difficulties.Length - 2, (_platformSpawnConfig.difficulties.Length - 2) / 2, 3) + 1;
        PlatformSpawnableData spawnableData = new PlatformSpawnableData(Vector3.zero, diff, Random.Range(0, _platformSpawnConfig.difficulties[diff].platforms.Length));

        spawner?.Spawn(spawnableData);
    }

    private void Despawn()
    {
        spawner?.Despawn();
    }
}