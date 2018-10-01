using System;
using System.Collections;
using System.Collections.Generic;
using Classes;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

public class PenguinListItem : MonoBehaviour
{
    public Button penguinImage;
    public Text penguinName;
    public Text penguinDescription;
    public Text penguinLevel;
    public Slider penguinProgress;
    public Button penguinLevelUp;
    public Text penguinLevelUpText;

    public bool progressComplete;

    private CurrencyController cController;

    public void populateViews(Penguin penguin)
    {
        cController = Camera.main.gameObject.GetComponent<CurrencyController>();

        penguinName.text = penguin.name;
        if (penguin.isOwned())
            penguinLevel.text = "Level " + penguin.getLevel();
        else
            penguinLevel.text = "";
        penguinLevelUpText.text = penguin.getUserFriendlyCost() + "F";

        penguinImage.onClick.AddListener(() =>
        {
            if (!progressComplete)
            {
                Invoke("finishProcess", penguin.baseTime);
            }
            else
            {
                collectIncome(penguin);
            }
        });

        penguinLevelUp.onClick.AddListener(() =>
        {
            if (cController.canAfford(penguin.getCost()))
            {
                Debug.Log("Level Up!");
                cController.spendFish(penguin.getCost());
                penguin.incrementLevel();
            }
        });
    }

    private void finishProcess()
    {
        Debug.Log("Complete");
        penguinProgress.value = 1;
        progressComplete = true;
    }

    private void collectIncome(Penguin penguin)
    {
        cController.addFish(penguin.getProduction(1));
        penguin.getProduction(1);
        Debug.Log("Income Collected");
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