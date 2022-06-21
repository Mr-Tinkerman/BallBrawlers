using UnityEngine;

public class PlatformSpawnableData : SpawnableData
{
    public int difficulty;
    public int platformIndex;

    public PlatformBehaviour behaviour;

    public PlatformSpawnableData(Vector3 position, int difficulty = 0, int platformIndex = 0, PlatformBehaviour behaviour = null)
    {
        // Base Class
        base.positionOffset = position;

        // Derived Class
        this.difficulty = difficulty;
        this.platformIndex = platformIndex;
        this.behaviour = behaviour;
    }
}