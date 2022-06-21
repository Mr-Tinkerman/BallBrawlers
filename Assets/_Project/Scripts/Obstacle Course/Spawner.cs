using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public abstract void Spawn(SpawnableData data);

    public abstract void Despawn();

    public abstract SpawnerConfig GetSpawnerConfig();
}