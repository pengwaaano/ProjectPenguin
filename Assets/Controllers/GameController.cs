using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float fishPerSecond = 0;

    public Text penguinText;
    public Text fpsText;
    public Text fishText;
    public UpgradeController upgradeController;
    public LocationController locationController;
    public CurrencyController currencyController;
    public PenguinController penguinController;

    void Update()
    {
        fishText.text = "Fish: " + currencyController.getFishString(false);
    }
   
}