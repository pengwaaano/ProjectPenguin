using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormulaManager : MonoBehaviour
{
    public static float costFormula(float baseCost, float level, float coefficient)
    {
        return baseCost * Mathf.Pow(coefficient, level);
    }

    public static float productionFormula(float baseProduction, float level, float multiplier)
    {
        return (baseProduction * level) * multiplier;
    }
}