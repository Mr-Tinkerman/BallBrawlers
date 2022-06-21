using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Platform Spawn Config", menuName = "Config/Platform Spawn Config")]
public class PlatformSpawnerConfig : SpawnerConfig
{
    [SerializeField]
    public PlatformGroup[] difficulties;

    public Material platformMaterial;
}
