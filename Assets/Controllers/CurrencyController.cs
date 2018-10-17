using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CurrencyController : MonoBehaviour
    {
        public List<CurrencyDenominations> denominations = new List<CurrencyDenominations>();

        public static string currencyName = "Plastic";
        public static string currencyPerSecondName = "PPS";
        
        private float currency = 100;

        private void Start()
        {
            Util.denominations = denominations;
        }

        public void add(float _income)
        {
            currency += _income;
        }

        public void spend(float _cost)
        {
            currency -= _cost;
        }

        public bool canAfford(float _cost)
        {
            return currency >= _cost;
        }

        public string getCurrencyString(bool scientific)
        {
            return scientific ? Util.CurrencyToStringScientific(currency) : Util.CurrencyToString(currency);
        }
    }
}