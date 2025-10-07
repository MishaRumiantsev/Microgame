using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    long currentLoad;
    long maxLoad;

    float loadTime;
    float unloadTime;
    float travelTime;

    string status;
    int currentFloor;
    int targetFloor;

    Timer timer;
    Vector3 defaultPosition;

    [SerializeField] SellPoint sellPoint;
    [SerializeField] List<Transform> elevatorPositions;
    [SerializeField] FloorsManager floorsManager;
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI currentLoadText;
    private void Start()
    {
        defaultPosition = gameObject.transform.position;

        maxLoad = 100;
        currentLoad = 0;

        loadTime = 3;
        unloadTime = 3;

        status = "inactive";
        currentFloor = -1;

        timer = GetComponent<Timer>();
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
                if (floorsManager.floors[i].currentIncome > 0 && i > currentFloor)
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
    }
    void SendToFloor()
    {
        status = $"Move to {targetFloor}";
        statusText.text = status;
        timer.StartTimer(travelTime);
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
        UpdateElevator();
        timer.StartTimer(loadTime);
        timer.OnTimerComplete += EndLoad;
    }
    void EndLoad()
    {
        timer.OnTimerComplete -= EndLoad;
        long freeToLoad = maxLoad - currentLoad;
        long loaded = Math.Min(freeToLoad, floorsManager.floors[currentFloor].currentIncome);
        floorsManager.floors[currentFloor].currentIncome -= loaded;
        floorsManager.floors[currentFloor].UpdateIncome();
        currentLoad += loaded;
        currentLoadText.text = currentLoad.ToString();
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
        UpdateElevator();
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
        currentLoadText.text = currentLoad.ToString();
        status = "inactive";
        statusText.text = status;
    }
    void UpdateElevator()
    {
        nameText.text = $"Elevator ({currentFloor})";
        if (currentFloor != -1)
        {
            gameObject.transform.position = elevatorPositions[currentFloor].position;
        }
        else
        {
            gameObject.transform.position = defaultPosition;
        }
    }
}
