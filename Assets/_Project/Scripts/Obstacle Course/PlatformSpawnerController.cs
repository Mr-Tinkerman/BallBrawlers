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

        Spawn(Vector2Int.zero);
    }

#if UNITY_EDITOR
    private void Update()
    {
        // Test if spawning works
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            int diff = TinkerLib.Random.WeightedRandom(_platformSpawnConfig.difficulties.Length - 2, (_platformSpawnConfig.difficulties.Length - 2) / 2, 3) + 1;
            Spawn(GetPlatform(0));
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket))
            Despawn();
    }
#endif

    private void Spawn(Vector2Int selected)
    {
        // TODO: randomize spawned platform
        PlatformSpawnableData spawnableData = new PlatformSpawnableData(Vector3.zero, selected.x, selected.y);

        spawner?.Spawn(spawnableData);
    }

    private void Despawn()
    {
        spawner?.Despawn();
    }

    private Vector2Int GetPlatform(int progress)
    {
        int difficulty = TinkerLib.Random.WeightedRandom(_platformSpawnConfig.difficulties.Length - 2, (_platformSpawnConfig.difficulties.Length - 2) / 2, 3) + 1;
        int platformIndex = Random.Range(0, _platformSpawnConfig.difficulties[difficulty].platforms.Length);
        return new Vector2Int(difficulty, platformIndex);
    }
}