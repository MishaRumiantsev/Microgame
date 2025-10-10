using UnityEngine;

public class NumberFormatter
{
    string[] numberSuffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", };
    /// <summary>
    /// Format een getal naar een verkorte weergave met achtervoegsels (bijv. 1,2K, 3,5M)
    /// </summary>
    public string Format(float pNumber)
    {
        string formattedNumber = "";
        int indexOfSuffixes = 0;
        while (pNumber >= 1000)
        {
            pNumber /= 1000;
            indexOfSuffixes++;
        }
        formattedNumber = pNumber.ToString("0.##");
        formattedNumber += numberSuffixes[indexOfSuffixes];
        return formattedNumber;
    }
}
