﻿using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CurrencyController : MonoBehaviour
    {
        public List<CurrencyDenominations> denominations = new List<CurrencyDenominations>();

        private float fish = 0;

        private void Start()
        {
            Util.denominations = denominations;
        }

        public void addFish(float _fish)
        {
            fish += _fish;
        }

        public string getFishString(bool scientific)
        {
            return scientific ? Util.CurrencyToStringScientific(fish) : Util.CurrencyToString(fish);
        }
    }
}