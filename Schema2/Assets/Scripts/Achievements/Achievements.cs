using System;
using System.Data.SqlTypes;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public IdleClickTest idleClickTest;

    //Alle achievements in de game
    public bool IkClicks = false;
    public bool IOkClicks = false;
    public bool IkMoney = false;
    public bool IOkMoney = false;
    public bool IOOkMoney = false;
    public bool ImMoney = false;
    public bool tweedeVerdieping = false;
    public bool derdeVerieping = false;
    public bool vierdeVerdieping = false;
    public bool vijfdeVerdieping = false;
    public bool bladSchaapSlak = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        switch (idleClickTest.clicks) {
            case 1000:
                IkClicks = true;
                break;
            case 10000:
                IOkClicks = true;
                break;
        }
        switch (idleClickTest.money) {
            case 1000:
                IkMoney = true;
                break;
            case 10000:
                IOkMoney = true;
                break;
            case 100000:
                IOOkMoney = true;
                break;
            case 1000000:
                ImMoney = true;
                break;
            default:
                break;
        }
    }*/
}
