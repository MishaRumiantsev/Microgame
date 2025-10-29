using System;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // Referentie naar UI-tekst met aantal vna coins
    [SerializeField] TextMeshProUGUI coinsText;
    NumberFormatter formatter;
    private void Start()
    {
        formatter = new NumberFormatter(); // initialiseer formatter
        coinsText.text = $"Coins: {formatter.FormatNumber(PlayerDataManager.Coins)}"; // update UI
    }
    /// <summary>
    /// Verandert aantal van de coins met opgegeven bedrag
    /// </summary>
    public void ChangeCoins(float pAmount)
    {
        PlayerDataManager.Coins += Convert.ToInt32(pAmount);
        // als de bedrag is positiev, voeg die bedrag ook aan totaal van coins
        if (pAmount > 0)
        {
            PlayerDataManager.totalCoins += Convert.ToInt32(pAmount);
        }
        coinsText.text = $"Coins: {formatter.FormatNumber(PlayerDataManager.Coins)}"; // update ui
    }
    /// <summary>
    /// Probeert opgegeven bedrag aan munten uit te geven, als het gelukt is, geeft true terug
    /// </summary>
    public bool TrySpendCoins(float pAmount)
    {
        // als speler genoeg coin geeft trek het bedrag af en geeft true terug, anders - geeft false terug
        if (PlayerDataManager.Coins >= pAmount)
        {
            ChangeCoins(-pAmount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GiveCoins(float pAmount)
    {
        ChangeCoins(pAmount);
    }
}
