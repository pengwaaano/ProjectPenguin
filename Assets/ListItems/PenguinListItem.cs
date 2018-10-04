using System;
using System.Collections;
using System.Collections.Generic;
using Classes;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

public class PenguinListItem : MonoBehaviour
{
    private Penguin penguin;
    
    public Button penguinImage;
    public Text penguinName;
    public Text penguinDescription;
    public Text penguinLevel;
    public Slider penguinProgress;
    public Button penguinLevelUp;
    public Text penguinLevelUpText;

    public bool progressComplete;
    private bool populationComplete;
    private PenguinProgressSlider sliderComponent;
    
    private CurrencyController cController;

    private void Update()
    {
        if (populationComplete)
        {
            updateViews();
        }
    }

    public void populateViews(Penguin p)
    {

        penguin = p;
        cController = Camera.main.gameObject.GetComponent<CurrencyController>();
        sliderComponent = penguinProgress.GetComponent<PenguinProgressSlider>();
        updateViews();

        penguinImage.onClick.AddListener(() =>
        {
            if (!progressComplete)
            {
                startProcess();
            }
            else
            {
                collectIncome(penguin);
                sliderComponent.finishTimer();
            }
        });

        penguinLevelUp.onClick.AddListener(() =>
        {
            if (cController.canAfford(penguin.getCost()))
            {
                cController.spendFish(penguin.getCost());
                penguin.incrementLevel();
            }
        });

        populationComplete = true;
    }

    public void startProcess()
    {
        Invoke("finishProcess", penguin.getTimeToComplete());
        sliderComponent.startTimer(penguin);
    }

    public void updateViews()
    {
        if (penguin.isOwned())
            penguinLevel.text = "Level " + penguin.getLevel();
        else
            penguinLevel.text = "";
        penguinLevelUpText.text = penguin.getUserFriendlyCost() + "F";
    }

    private void finishProcess()
    {
        penguinProgress.value = 1;
        progressComplete = true;
        if (penguin.isManaged())
        {
            collectIncome(penguin);
            sliderComponent.finishTimer();
            startProcess();
        }
    }

    private void collectIncome(Penguin penguin)
    {
        cController.addFish(penguin.getProduction(1));
        penguin.getProduction(1);
        penguinProgress.value = 0;
        progressComplete = false;
    }

    IEnumerator animateSliderOverTime(float seconds)
    {
        float animationTime = 0f;
        while (true)
        {
            if (animationTime <= seconds)
            {
                animationTime += Time.deltaTime;
                float lerpValue = animationTime / seconds;
                penguinProgress.value = Mathf.Lerp(0, 1, lerpValue);
                Util.Log("Penguin", "" + animationTime);
                yield return null;
            }
        }
    }
}