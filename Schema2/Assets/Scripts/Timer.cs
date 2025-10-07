using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timeRemaining;
    float duration;
    public float timeRemainingPercentage;
    public bool isRunning;
    public event Action OnTimerComplete;
    private void Update()
    {
        if (isRunning)
        {
            timeRemainingPercentage = ((duration - timeRemaining) / duration) * 100f;
            timeRemainingPercentage = Mathf.Round(timeRemainingPercentage * 100f) / 100f;
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                isRunning = false;
                OnTimerComplete?.Invoke();
            }
        }
    }
    public void StartTimer(float pDuration)
    {
        duration = pDuration;
        timeRemaining = pDuration;
        isRunning = true;
    }
}
