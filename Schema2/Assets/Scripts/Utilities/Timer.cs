using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // hoeveel tijd is er nog over
    float timeRemaining;
    // duur van de timer
    float duration;
    // percentage van voortgang
    public float progresPercentage;
    // is de timer active
    public bool isRunning;
    //event, die wordt aangeroepen waneer de timer klaar is
    public event Action OnTimerComplete;
    private void Update()
    {
        // als de timer active is
        if (isRunning)
        {
            // bereiken percentage van voortgang
            progresPercentage = ((duration - timeRemaining) / duration) * 100f;
            progresPercentage = Mathf.Round(progresPercentage * 100f) / 100f;
            // verminder het reterende tijd met de tijd van de laatste frame
            timeRemaining -= Time.deltaTime;
            // als er us geen resterende tijd stopt de timer en roept het event aan
            if (timeRemaining <= 0)
            {
                isRunning = false;
                OnTimerComplete?.Invoke();
            }
        }
    }
    /// <summary>
    /// start de timer met opgegeven duur
    /// </summary>
    public void StartTimer(float pDuration)
    {
        duration = pDuration;
        timeRemaining = pDuration;
        isRunning = true;
    }
}
