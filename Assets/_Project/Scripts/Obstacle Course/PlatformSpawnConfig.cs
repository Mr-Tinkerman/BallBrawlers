using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Platform Spawn Config", menuName = "Config/Platform Spawn Config")]
public class PlatformSpawnConfig : ScriptableObject
{
    [SerializeField]
    public PlatformGroup[] platformGroups;

    public Material platformMaterial;
}
