using System.Collections;
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

    private void processFish()
    {
        float fishToProcess = fish > outputPerSecond ? outputPerSecond : fish;
        StartCoroutine(finishProcess(fishToProcess));
    }

    IEnumerator finishProcess(float f)
    {
        yield return new WaitForSeconds(timeToProcess);
        cController.addFish(f);
        fish -= f;
    }
}
