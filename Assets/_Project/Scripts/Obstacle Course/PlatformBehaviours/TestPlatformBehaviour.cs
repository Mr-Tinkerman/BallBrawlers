using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Test", menuName = "Behaviour/Platform/Test")]
public class TestPlatformBehaviour : PlatformBehaviour
{
    public override void OnExecute(float deltaTime)
    { Debug.Log("Execute!  Delta Time: " + deltaTime); }

    public override void OnEnter(Spawner spawner)
    { Debug.Log("Enter!  Spawner: " + spawner.name); }

    public override void OnExit()
    { Debug.Log("Exit!"); }
}