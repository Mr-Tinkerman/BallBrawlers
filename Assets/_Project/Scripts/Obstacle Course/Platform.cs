using UnityEngine;

[System.Serializable]
public class PlatformType
{
    public Mesh mesh;

    public PlatformBehaviour behaviour;
}

[System.Serializable]
public struct PlatformGroup
{
    public PlatformType[] platforms;
}