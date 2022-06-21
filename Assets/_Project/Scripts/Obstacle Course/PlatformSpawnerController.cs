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
        PlatformSpawnableData spawnableData = new PlatformSpawnableData(Vector3.zero, 1, 0);

        spawner?.Spawn(spawnableData);
    }

    private void Despawn()
    {
        spawner?.Despawn();
    }
}