using UnityEngine;
using TMPro;

public class IdleClickTest : MonoBehaviour
{
    public int money;
    public int pasiveMoney;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI pasiveMoneyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = $"Money: {money.ToString()}";
        pasiveMoneyText.text = $"pMoney: {pasiveMoney.ToString()}";
    }

    public void OnClick() 
    {
        money++;
    }

    //invoke cancelen, tijd verlagen en dan weer aanzetten
    public void OnClickPasive()
    {
        InvokeRepeating("PasiveMoney", 1f, 3f);
    }


    public void PasiveMoney()
    {
        pasiveMoney++;
    }

    

}
