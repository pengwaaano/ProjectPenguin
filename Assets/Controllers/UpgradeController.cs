using System;
using System.Collections.Generic;
using System.Linq;
using Classes;
using UnityEngine;

namespace Controllers
{

    public class UpgradeController : MonoBehaviour
    {
        private List<Upgrade> allUpgrades = new List<Upgrade>();
        private List<Upgrade> allOwnedUpgrades = new List<Upgrade>();

        private float fishPerPenguin = 1;

        public float getFishPerPenguinMultiplier()
        {
            return fishPerPenguin;
        }

        private void setFishPerPenguinMultiplier(float f)
        {
            fishPerPenguin = f;
        }

        public void recalculateUpgradeMultipliers()
        {
            IEnumerable<UpgradableAttributes> values =
                Enum.GetValues(typeof(UpgradableAttributes)).Cast<UpgradableAttributes>();

            foreach (var attribute in values)
            {
                var upgradesForThisAttribute =
                    allOwnedUpgrades.Where(upgrade => upgrade.getAttribute() == attribute).ToList();
                calculateMultiplier(upgradesForThisAttribute, attribute);
            }
        }

        private void calculateMultiplier(IEnumerable<Upgrade> upgrades, UpgradableAttributes attribute)
        {
            float multiplier = 1.0f;
            foreach (var upgrade in upgrades)
            {
                if (upgrade.isAdditive())
                {
                    multiplier += upgrade.getValueForCalculation();
                }
                else if (upgrade.isMultiplicative())
                {
                    multiplier *= upgrade.getValueForCalculation();
                }
            }

            setMultiplierForAttribute(attribute, multiplier);
        }

        private void setMultiplierForAttribute(UpgradableAttributes attribute, float multiplier)
        {
            switch (attribute)
            {
                case UpgradableAttributes.FishPerPenguin:
                    setFishPerPenguinMultiplier(multiplier);
                    break;
                default:
                    Util.Log("setMultiplierForAttribute", " This probably isn't right :(");
                    break;
            }
        }
    }
}