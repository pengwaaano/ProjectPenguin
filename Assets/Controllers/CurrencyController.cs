using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CurrencyController : MonoBehaviour
    {
        public List<CurrencyDenominations> denominations = new List<CurrencyDenominations>();

        private float fish = 100;

        private void Start()
        {
            Util.denominations = denominations;
        }

        public void addFish(float _fish)
        {
            fish += _fish;
        }

        public void spendFish(float _fish)
        {
            fish -= _fish;
        }

        public bool canAfford(float _cost)
        {
            return fish >= _cost;
        }

        public string getFishString(bool scientific)
        {
            return scientific ? Util.CurrencyToStringScientific(fish) : Util.CurrencyToString(fish);
        }
    }
}