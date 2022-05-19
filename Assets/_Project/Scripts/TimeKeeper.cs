using System.Security;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class TimeKeeper : MonoBehaviour
{
    private float startingTime = 30;
    private float timeLeftSeconds;

    private bool paused = false;

    public static TimeKeeper Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        ResetTime();
    }

    void Update()
    {
        // Game timer countdown
        if (timeLeftSeconds > 0 && !paused)
        {
            timeLeftSeconds -= Time.deltaTime;
            timeLeftSeconds = Mathf.Max(timeLeftSeconds, 0);
        }
        else
        {
            // Game Over
        }
    }

    public void AddTime(int seconds)
    {
        timeLeftSeconds += seconds;
    }

    public void RemoveTime(int seconds)
    {
        timeLeftSeconds -= seconds;
        timeLeftSeconds = Mathf.Max(timeLeftSeconds, 0);
    }

    public float GetTime()
    {
        return timeLeftSeconds;
    }

    public void ResetTime()
    {
        timeLeftSeconds = startingTime;
    }

    public void PauseTime()
    {
        paused = true;
    }

    public void UnpauseTime()
    {
        paused = false;
    }
}