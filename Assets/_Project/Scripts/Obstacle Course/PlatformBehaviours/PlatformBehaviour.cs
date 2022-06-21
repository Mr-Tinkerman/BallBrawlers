using UnityEngine;

[System.Serializable]
public abstract class PlatformBehaviour : ScriptableObject
{
    public abstract void OnExecute(float deltaTime);
    public abstract void OnEnter(Spawner spawner);
    public abstract void OnExit();
}