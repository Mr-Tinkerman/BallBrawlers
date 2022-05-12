using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchItem : MonoBehaviour
{
    [SerializeField]
    private int seconds = 3;

    void OnTriggerEnter()
    {
        TimeKeeper.Instance.AddTime(seconds);

        DestroyImmediate(this.gameObject);
    }
}