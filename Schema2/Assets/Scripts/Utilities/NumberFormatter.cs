public class NumberFormatter
{
    /// <summary>
    /// Formatteert een getal naar een verkorte weergave met achtervoegsels (bijv. 1,2K, 3,5M)
    /// </summary>
    public string FormatNumber(float pNumber)
    {
        // array met achtervoegsels voor duizends, miljoenen, enz,
        string[] numberSuffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", };
        // variabele voor geformateerde getal
        string formattedNumber = "";
        // index om achtervoegsel te kiezen
        int indexOfSuffixes = 0;
        // verklein getal, zodat het minder dan 1000 wordt en kies de juiste index van het achtervoegsel
        while (pNumber >= 1000)
        {
            pNumber /= 1000;
            indexOfSuffixes++;
        }
        // format getal, zodat er maximaal twee cijfers achter de komma blijven
        formattedNumber = pNumber.ToString("0.##");
        while (formattedNumber.Length > 4)
        {
            formattedNumber = formattedNumber.Substring(0, formattedNumber.Length - 1);
        }
        // als de laatste teken is "." of "," verwijder het
        if (formattedNumber.EndsWith(".") || formattedNumber.EndsWith(","))
        {
            formattedNumber = formattedNumber.Substring(0, formattedNumber.Length - 1);
        }
        // voeg achtervoegsel toe geformateerde getal
        formattedNumber += numberSuffixes[indexOfSuffixes];
        return formattedNumber;
    }
    /// <summary>
    /// Formatteert seconden naar een leesbare tijd (bijv. 3700 => 1h 1m. 40s)
    /// </summary>
    public string FormatTime(float pSeconds)
    {
        // variabele voor geformateerde getal
        string formattedTime = "";
        // verklein getal, z0dat er geen uren blijft en voeg aantal van uren aan de geformateerde getal
        if (pSeconds >= 3600)
        {
            float remainingSeconds = pSeconds % 3600; // resterende seconden na uren
            int hours = (int)(pSeconds - remainingSeconds) / 3600; // aantal van uren bereiken
            pSeconds = remainingSeconds;
            formattedTime += $"{hours}h "; // voeg uren toe geformateerde getal
        }
        // verklein getal, z0dat er geen minuten blijft en voeg aantal van uren aan de geformateerde getal
        if (pSeconds >= 60)
        {
            float remainingSeconds = (pSeconds % 60); // resterende seconden na minuten
            int minutes = (int)(pSeconds - remainingSeconds) / 60;// aantal van minuten bereiken 
            pSeconds = remainingSeconds;
            formattedTime += $"{minutes}m "; // voeg minuten toe geformateerde getal
        }
        // neemt alle seconden van getal en voeg ze aan de geformateerde getal
        if (pSeconds > 0)
        {
            formattedTime += $"{pSeconds:0.##}s";
        }
        return formattedTime;
    }
}
