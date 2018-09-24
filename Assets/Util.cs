using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static List<CurrencyDenominations> denominations;
    
    public static string CurrencyToString(double valueToConvert)
    {
        int scale = 0;
        double v = valueToConvert;
        while (v >= 1000d)
        {
            v /= 1000d;
            scale++;
            if (scale >= denominations.Count)
                return valueToConvert.ToString("e2");
        }
        return v.ToString("0.##") + denominations[scale].symbol;
    }

    public static string CurrencyToStringScientific(double valueToConvert)
    {
        return valueToConvert.ToString("e2");
    }
    
    public static string getUnitSymbolForUnit(Unit u)
    {
        switch (u)
        {
            case Unit.Percent:
                return "%";
            default:
                return "";
        }
    }

    public static string getAttributeStringForUpgradableAttribute(UpgradableAttributes u)
    {
        switch (u)
        {
            case UpgradableAttributes.FishPerPenguin:
                return StringConstants.fishPerPenguin;
            case UpgradableAttributes.FishPerSecond:
                return StringConstants.fishPerSecond;
            default:
                return "";
        }
    }

    public static void Log(string tag, string message)
    {
        Debug.unityLogger.Log(tag, message);
    }
}