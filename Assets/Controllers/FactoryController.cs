﻿using System.Collections;
using System.Collections.Generic;
using Controllers;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class FactoryController : MonoBehaviour
{
    public Text factoryCount;

    public float outputPerSecond;
    public float timeToProcess;
    public float fish;
    public float level;
    public float baseCost;
    public float coefficient;

    private CurrencyController cController;

    void Start()
    {
        cController = gameObject.GetComponent<CurrencyController>();
        InvokeRepeating("processFish", 0, 1);
    }

    void Update()
    {
        factoryCount.text = Util.CurrencyToString(fish);
    }

    public void addFish(float _fish)
    {
        fish += _fish;
    }

    public float getCost()
    {
        return baseCost * Mathf.Pow(coefficient, level);
    }

    private float getOutputPerSecond(float multiplier)
    {
        return (outputPerSecond * level) * multiplier;
    }

    private void processFish()
    {
        float fishToProcess = fish > getOutputPerSecond(1) ? getOutputPerSecond(1) : fish;
        StartCoroutine(finishProcess(fishToProcess));
    }

    IEnumerator finishProcess(float f)
    {
        yield return new WaitForSeconds(timeToProcess);
        cController.addFish(f);
        fish -= f;
    }

    public void upgradeFactory()
    {
        if (cController.canAfford(getCost()))
        {
            cController.spendFish(getCost());
            level += 1;
        }
    }
}