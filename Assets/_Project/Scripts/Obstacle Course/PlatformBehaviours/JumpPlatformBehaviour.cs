using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "JumpBehaviour", menuName = "Behaviour/Platform/Jump")]
public class JumpPlatformBehaviour : PlatformBehaviour
{
    [SerializeField]
    private Vector2 _offsetRange = Vector2.up;

    [SerializeField]
    private Vector2Int[] _nextPlatformIndices;

    private Vector3 _positionCache = Vector3.zero;

    private int _index;

    public override void OnExecute(float deltaTime) { }

    public override void OnEnter(Spawner spawner)
    {
        _positionCache = Vector3.zero;
        _positionCache.z = Random.Range(_offsetRange.x, _offsetRange.y);

        _index = Random.Range(0, _nextPlatformIndices.Length);

        var data = new PlatformSpawnableData(_positionCache, _nextPlatformIndices[_index].x, _nextPlatformIndices[_index].y);
        spawner.Spawn(data);
    }

    public override void OnExit() { }
}