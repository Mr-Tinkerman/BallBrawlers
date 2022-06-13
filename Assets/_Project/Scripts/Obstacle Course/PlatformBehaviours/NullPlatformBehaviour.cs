using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Null", menuName = "Behaviour/Platform/Null")]
public class NullPlatformBehaviour : PlatformBehaviour
{
    public override void OnExecute() { }
    public override void OnEnter() { }
    public override void OnExit() { }
}