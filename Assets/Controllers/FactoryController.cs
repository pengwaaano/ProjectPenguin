using System.Collections;
using System.Collections.Generic;
using Controllers;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class FactoryController : MonoBehaviour
{
    public Text factoryCount;
    public Text factoryUpgradeText;

    public float outputPerSecond;
    public float timeToProcess;
    public float storage;
    public float level;
    public float baseCost;
    public float coefficient;
    public float multiplier = 1;

    private CurrencyController cController;

    void Start()
    {
        cController = gameObject.GetComponent<CurrencyController>();
        InvokeRepeating("process", 0, 1);
    }

    void Update()
    {
        factoryCount.text = Util.CurrencyToString(storage);
        factoryUpgradeText.text = "Upgrade (" + Util.CurrencyToString(getCost()) + ")";
    }

    public void add(float _income)
    {
        storage += _income;
    }

    public float getCost()
    {
        return FormulaManager.costFormula(baseCost, level, coefficient);
    }

    public float getOutputPerSecond()
    {
        return FormulaManager.productionFormula(outputPerSecond,level, multiplier);
    }

    private void process()
    {
        float fishToProcess = storage > getOutputPerSecond() ? getOutputPerSecond() : storage;
        StartCoroutine(finishProcess(fishToProcess));
    }

    IEnumerator finishProcess(float f)
    {
        yield return new WaitForSeconds(timeToProcess);
        cController.add(f);
        storage -= f;
    }

    public void upgradeFactory()
    {
        if (cController.canAfford(getCost()))
        {
            cController.spend(getCost());
            level += 1;
        }
    }
   
}