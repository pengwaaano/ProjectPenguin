﻿using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Classes
{
    [Serializable]
    public class Penguin
    {
        public string name;
        public string description;
        public float coefficient;
        public float baseProduction;
        public float baseTime;
        private float baseCost;
        private float cost;
        private int level;
        public bool hasManager;

        public float getBaseCost()
        {
            return baseCost;
        }

        public void setBaseCost(float f)
        {
            baseCost = f;
        }

        public string getUserFriendlyCost()
        {
            return getCost().ToString("0.##");
        }
        
        public float getCost()
        {
            return FormulaManager.costFormula(baseCost, coefficient, level);
        }

        public float getProduction(float multiplier)
        {
            return FormulaManager.productionFormula(baseProduction, level, multiplier);
        }

        public float getTimeToComplete()
        {
            return baseTime;
        }

        public bool isOwned()
        {
            return level > 0;
        }
    
        public float getLevel()
        {
            return level;
        }

        public void setLevel(int i)
        {
            level = i;
        }
    
        public void incrementLevel()
        {
            level++;
        }

        public void setHasManager(bool b)
        {
            this.hasManager = b;
        }
        
        public bool isManaged()
        {
            return hasManager;
        }
    }
}