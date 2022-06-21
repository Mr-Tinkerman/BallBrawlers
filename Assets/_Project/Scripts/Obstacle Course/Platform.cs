using UnityEngine;

[System.Serializable]
public struct PlatformGroup
{
    [System.Serializable]
    public class PlatformData
    {
        public Mesh mesh;

        public PlatformBehaviour behaviour;
    }

    public PlatformData[] platforms;
}