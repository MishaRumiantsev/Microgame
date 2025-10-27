using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // variabelen voor het beheren van current load
    float currentLoad;
    [SerializeField] TextMeshProUGUI currentLoadText;

    public float loadTime;
    public float maxLoad;

    // variabelen voor het beheren van de liftbeweging
    int currentFloor;
    int targetFloor;
    bool isMoving;
    float elapsedTime;
    float travelTime;
    Vector3 startPosition;
    Vector3 targetPosition;
    [SerializeField] Transform defaultPosition;
    [SerializeField] List<Transform> elevatorPositions;

    string status;
    Timer timer;
    NumberFormatter formatter;

    [SerializeField] SellPoint sellPoint;
    [SerializeField] FloorsManager floorsManager;
    [SerializeField] TextMeshProUGUI statusText;
    private void Start()
    {
        formatter = new NumberFormatter();

        currentLoad = 0;
        currentLoadText.text = formatter.FormatNumber(currentLoad);

        loadTime = 3;

        status = "inactive";
        currentFloor = -1;

        isMoving = false;

        timer = GetComponent<Timer>();
    }
    private void Update()
    {
        if (isMoving)
        {
            if (elapsedTime < travelTime)
            {
                elapsedTime += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / travelTime);
            }
            else
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
    public void OnClick()
    {
        if (status == "inactive")
        {
            ChooseNextTargetFloor();
            if (targetFloor != currentFloor)
            {
                SendToFloor();
            }
        }
    }
    /// <summary>
    /// kiest volgende doelverdieping voor de lift
    /// </summary>
    void ChooseNextTargetFloor()
    {
        if (currentLoad != maxLoad)
        {
            for (int i = 0; i < floorsManager.floors.Count; i++)
            {
            FloorManager floor = floorsManager.floors[i].GetComponent<FloorManager>();
                if (floor.currentResources > 0 && i > currentFloor)
                {
                    targetFloor = i;
                    travelTime = targetFloor - currentFloor;
                    return;
                }
            }
            ChooseStorage();
        }
        else
        {
            ChooseStorage();
        }

    }
    /// <summary>
    /// kiest sellPoint als volgende doelverdieping
    /// </summary>
    void ChooseStorage()
    {
        targetFloor = -1;
        travelTime = targetFloor - currentFloor;
        travelTime = Mathf.Abs(travelTime);
        if (currentLoad == maxLoad)
        {
            travelTime *= 1.2f;
        }
    }
    /// <summary>
    /// stuurt de lift naar de doelverdieping 
    /// </summary>
    void SendToFloor()
    {
        status = $"Move to {targetFloor}";
        statusText.text = status;
        timer.StartTimer(travelTime);
        StartMoving();
        if (targetFloor != -1)
        {
            timer.OnTimerComplete += StartLoad;
        }
        else
        {
            timer.OnTimerComplete += StartUnload;
        }
    }
    /// <summary>
    /// start het laadprocess van de lift
    /// </summary>
    void StartLoad()
    {
        timer.OnTimerComplete -= StartLoad;
        currentFloor = targetFloor;
        status = $"Load from {currentFloor}";
        statusText.text = status;
        timer.StartTimer(loadTime);
        timer.OnTimerComplete += EndLoad;
    }
    /// <summary>
    /// Voltooid het laadprocess van de lift
    /// </summary>
    void EndLoad()
    {
        timer.OnTimerComplete -= EndLoad;
        float freeToLoad = maxLoad - currentLoad;
        FloorManager floor = floorsManager.floors[currentFloor].GetComponent<FloorManager>();

        float loaded = Math.Min(freeToLoad, floor.currentResources);
        floor.ChangeCurrentResources(-loaded);
        currentLoad += loaded;
        currentLoadText.text = formatter.FormatNumber(currentLoad);
        ChooseNextTargetFloor();
        if (currentFloor != targetFloor)
        {
            SendToFloor();
        }
        else
        {
            StartLoad();
        }
    }
    /// <summary>
    /// start het unlaadprocess van de lift
    /// </summary>
    void StartUnload()
    {
        timer.OnTimerComplete -= StartUnload;
        currentFloor = targetFloor;
        status = "Unload";
        statusText.text = status;
        timer.StartTimer(loadTime);
        timer.OnTimerComplete += EndUnload;
    }
    /// <summary>
    /// Voltooid het unlaadprocess van de lift
    /// </summary>
    void EndUnload()
    {
        timer.OnTimerComplete -= EndUnload;
        sellPoint.AddResources(currentLoad);
        currentLoad = 0;
        currentLoadText.text = formatter.FormatNumber(currentLoad);
        status = "inactive";
        statusText.text = status;
    }
    /// <summary>
    /// start beweging process van de lift
    /// </summary>
    void StartMoving()
    {
        isMoving = true;
        startPosition = transform.position;
        if (targetFloor != -1)
        {
            targetPosition = elevatorPositions[targetFloor].position;
        }
        else
        {
            targetPosition = defaultPosition.position;
        }
        elapsedTime = 0f;
    }
}
