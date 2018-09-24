using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float fishPerSecond = 0;
    private float penguins = 0;

    public Text penguinText;
    public Text fpsText;
    public Text fishText;
    public UpgradeController upgradeController;
    public LocationController locationController;
    public CurrencyController currencyController;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("onTick", 0, 1);
    }

    public void onTick()
    {
        currencyController.addFish(fishPerSecond);
        fishText.text = "Fish: " + currencyController.getFishString(false);
    }

    public void addPenguin()
    {
        if (penguins < locationController.getCurrentCapacity())
        {
            penguins++;
            penguinText.text = "Penguins: " + penguins;
            dispatchPenguin();
            recalculateFps();
        }
        else
        {
            Debug.Log("You've hit max capacity :(");
        }
    }

    private void recalculateFps()
    {
        fishPerSecond = penguins * (GameConstants.fishPerPenguinBase * upgradeController.getFishPerPenguinMultiplier());
        fpsText.text = "FPS: " + fishPerSecond.ToString("F2");
    }

    private void dispatchPenguin()
    {
        //penguin animate. Maybe a callback is needed?
    }
}