using System.Collections.Generic;
using UnityEngine;

public class FloorsManager : MonoBehaviour
{
    public List<FloorManager> floors;
    private void Start()
    {
        for (int i = 0; i < floors.Count; i++)
        {
            floors[i].SetUpFloor(0, 10, 50, 5);
        }
    }
}
