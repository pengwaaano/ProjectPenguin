using System;

namespace Classes
{
    [Serializable]
    public class Upgrade
    {
        private string name;
        private string subText;
        private bool additive;
        private bool multiplicative;
        private UpgradableAttributes attribute;
        private float value;
        private Unit unit;
        private double cost;

        public string getName()
        {
            return name;
        }

        public void setName(string s)
        {
            name = s;
        }

        public string getSubText()
        {
            return subText;
        }

        public void setSubText(string s)
        {
            subText = s;
        }

        public bool isAdditive()
        {
            return additive;
        }

        public void setAdditive(bool b)
        {
            additive = b;
        }

        public bool isMultiplicative()
        {
            return multiplicative;
        }

        public void setMultiplicative(bool b)
        {
            multiplicative = b;
        }

        public UpgradableAttributes getAttribute()
        {
            return attribute;
        }

        public void setAttribute(UpgradableAttributes u)
        {
            attribute = u;
        }

        public float getValue()
        {
            return value;
        }

        public float getValueForCalculation()
        {
            switch (unit)
            {
                case Unit.Percent:
                    return 1 + value / 100;
                default:
                    return value;
            }
        }

        public void setValue(float f)
        {
            value = f;
        }

        public Unit getUnit()
        {
            return unit;
        }

        public void setUnit(Unit u)
        {
            unit = u;
        }

        public double getCost()
        {
            return cost;
        }

        public void setCost(double f)
        {
            cost = f;
        }

        public override string ToString()
        {
            string upgradeString = "Increase " + Util.getAttributeStringForUpgradableAttribute(attribute) + " by " + value +
                                   Util.getUnitSymbolForUnit(unit) + ".";
            return upgradeString;
        }
    }
}