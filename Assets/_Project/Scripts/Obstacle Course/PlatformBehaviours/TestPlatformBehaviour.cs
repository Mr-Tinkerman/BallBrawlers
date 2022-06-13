using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Test", menuName = "Behaviour/Platform/Test")]
public class TestPlatformBehaviour : PlatformBehaviour
{
    public override void OnExecute() { Debug.Log("Execute!"); }
    public override void OnEnter() { Debug.Log("Enter!"); }
    public override void OnExit() { Debug.Log("Exit!"); }
}