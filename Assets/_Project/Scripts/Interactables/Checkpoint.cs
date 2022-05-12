#define ENABLE_CHECKPOINT

using UnityEngine;

[RequireComponent(typeof(StopwatchItem))]
public class Checkpoint : MonoBehaviour
{
    #if ENABLE_CHECKPOINT
    private StopwatchItem stopwatch;

    void Awake()
    {
        stopwatch = GetComponent<StopwatchItem>();
    }

    void OnTriggerEnter()
    {
        Debug.LogWarning("Checkpoint not implemented!");
    }
    #endif
}
