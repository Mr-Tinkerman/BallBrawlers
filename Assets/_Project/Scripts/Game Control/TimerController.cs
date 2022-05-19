using System;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static event Action<float> OnTimerTick;

    void Update()
    {
        OnTimerTick?.Invoke(Time.deltaTime);
    }
}
