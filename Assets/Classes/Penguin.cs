using System;
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

        public float getBaseCost()
        {
            return baseCost;
        }

        public void setBaseCost(float f)
        {
            baseCost = f;
        }

        public float getUserFriendlyCost()
        {
            return getCost();
        }
        
        public float getCost()
        {
            return baseCost * Mathf.Pow(coefficient, level);
        }

        public float getProduction(float multiplier)
        {
            return (baseProduction * level) * multiplier;
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
    }
}