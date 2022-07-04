using UnityEngine;

public class RandomDistributionVisualizer : MonoBehaviour
{
    [SerializeField]
    private int _DFI;

    [SerializeField]
    private int _focus;

    [SerializeField]
    private int _randomRange = 3;

    [SerializeField]
    private int _sampleSize = 100000;

    private int[] _results;

    void OnDrawGizmos()
    {
        _results = new int[_randomRange];

        for (int i = 0; i < _sampleSize; ++i)
        {
            // float rand = TinkerLib.Random.WeightedRandom(((float)_DFI) / ((float)_randomRange), _focus) * _randomRange;
            int randInt = TinkerLib.Random.WeightedRandom(_randomRange - 1, _DFI, _focus);
            // Debug.Log(rand);

            // int randInt = Mathf.Min(Mathf.RoundToInt(rand), _randomRange - 1);
            _results[randInt]++;
        }

        for (int i = 0; i < _results.Length; ++i)
        {
            if (_DFI == i)
                Gizmos.color = Color.green;
            Gizmos.DrawCube(Vector3.zero + Vector3.forward * i, Vector3.right * _results[i] / _sampleSize * _randomRange + Vector3.forward + Vector3.up);
            Gizmos.color = Color.white;
        }
    }

    void OnValidate()
    {
        _DFI = Mathf.Clamp(_DFI, 0, _randomRange - 1);
        _focus = (int)Mathf.Max(_focus, 1);
        // _focus = Mathf.Clamp01(_focus);
    }
}