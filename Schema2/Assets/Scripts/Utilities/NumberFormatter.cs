public class NumberFormatter
{
    /// <summary>
    /// Formatteert een getal naar een verkorte weergave met achtervoegsels (bijv. 1,2K, 3,5M)
    /// </summary>
    public string FormatNumber(float pNumber)
    {
        string[] numberSuffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", };
        string formattedNumber = "";
        int indexOfSuffixes = 0;
        while (pNumber >= 1000)
        {
            pNumber /= 1000;
            indexOfSuffixes++;
        }
        formattedNumber = pNumber.ToString("0.##");
        while (formattedNumber.Length > 4)
        {
            formattedNumber = formattedNumber.Substring(0, formattedNumber.Length - 1);
        }
        if (formattedNumber.EndsWith("."))
        {
            formattedNumber = formattedNumber.Substring(0, formattedNumber.Length - 1);
        }
        formattedNumber += numberSuffixes[indexOfSuffixes];
        return formattedNumber;
    }
    /// <summary>
    /// Formatteert seconden naar een leesbare tijd (bijv. 3700 => 1h 1m. 40s)
    /// </summary>
    public string FormatTime(float pSeconds)
    {
        string formattedTime = "";
        int hours = 0;
        int minutes = 0;
        if (pSeconds >= 3600)
        {
            float remainingSeconds = pSeconds % 3600;
            hours = (int)(pSeconds - remainingSeconds) / 3600;
            pSeconds = remainingSeconds;
            formattedTime += $"{hours}h ";
        }
        if (pSeconds >= 60)
        {
            float remainingSeconds = (pSeconds % 60);
            minutes = (int)(pSeconds - remainingSeconds) / 60;
            pSeconds = remainingSeconds;
            formattedTime += $"{minutes}m ";
        }
        if (pSeconds > 0)
        {
            formattedTime += $"{pSeconds:0.##}s";
        }
        return formattedTime;
    }
}
