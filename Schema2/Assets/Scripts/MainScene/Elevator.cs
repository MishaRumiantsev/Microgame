using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    float currentLoad;

    float maxLoad;

    float loadTime;
    float unloadTime;
    float travelTime;
    float elapsedTime;
    bool isMoving;


    string status;
    int currentFloor;
    int targetFloor;

    Timer timer;
    NumberFormatter formatter;

    Vector3 defaultPosition;
    Vector3 startPosition;
    Vector3 targetPosition;
    [SerializeField] List<Transform> elevatorPositions;
    [SerializeField] TextMeshProUGUI currentLoadText;
    [SerializeField] SellPoint sellPoint;
    [SerializeField] FloorsManager floorsManager;
    [SerializeField] TextMeshProUGUI statusText;
    private void Start()
    {
        formatter = new NumberFormatter();

        defaultPosition = gameObject.transform.position;

        maxLoad = 100;
        currentLoad = 0;
        currentLoadText.text = formatter.Format(currentLoad);

        loadTime = 3;
        unloadTime = 3;

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
    void ChooseNextTargetFloor()
    {
        if (currentLoad != maxLoad)
        {
            for (int i = 0; i < floorsManager.floors.Count; i++)
            {
                if (floorsManager.floors[i].currentResources > 0 && i > currentFloor)
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
    void StartLoad()
    {
        timer.OnTimerComplete -= StartLoad;
        currentFloor = targetFloor;
        status = $"Load from {currentFloor}";
        statusText.text = status;
        timer.StartTimer(loadTime);
        timer.OnTimerComplete += EndLoad;
    }
    void EndLoad()
    {
        timer.OnTimerComplete -= EndLoad;
        float freeToLoad = maxLoad - currentLoad;
        float loaded = Math.Min(freeToLoad, floorsManager.floors[currentFloor].currentResources);
        floorsManager.floors[currentFloor].ChangeCurrentResources(-loaded);
        currentLoad += loaded;
        currentLoadText.text = formatter.Format(currentLoad);
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
    void StartUnload()
    {
        timer.OnTimerComplete -= StartUnload;
        currentFloor = targetFloor;
        status = "Unload";
        statusText.text = status;
        timer.StartTimer(unloadTime);
        timer.OnTimerComplete += EndUnload;
    }
    void EndUnload()
    {
        timer.OnTimerComplete -= EndUnload;
        sellPoint.AddResources(currentLoad);
        currentLoad = 0;
        currentLoadText.text = formatter.Format(currentLoad);
        status = "inactive";
        statusText.text = status;
    }
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
            targetPosition = defaultPosition;
        }
        elapsedTime = 0f;
    }
}
