using UnityEngine;

[System.Serializable]
public abstract class PlatformBehaviour : ScriptableObject
{
    public abstract void OnExecute();
    public abstract void OnEnter();
    public abstract void OnExit();
}