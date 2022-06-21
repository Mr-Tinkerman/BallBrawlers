using UnityEngine;

public abstract class Spawnable : MonoBehaviour
{
    public abstract void Init(SpawnerConfig config);

    public abstract void OnTick(float deltaTime);
    public abstract void OnSpawn(SpawnableData data);
    public abstract void OnDespawn();
}