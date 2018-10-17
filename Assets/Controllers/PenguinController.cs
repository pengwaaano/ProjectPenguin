using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;

public class PenguinController : MonoBehaviour {

	public List<Penguin> penguins = new List<Penguin>();
	
	void Awake()
	{
		for (int i = 0; i < penguins.Count; i++)
		{
//			penguins[i].setCapacity(getCapacityForIndex(i));
			penguins[i].setBaseCost(getCostForIndex(i));
		}
		
		penguins[0].setLevel(1);
	}

	private float getCostForIndex(int index)
	{
		return 3.738f + Mathf.Pow(index, 10) * 60;
	}

	public float getIncomePerSecond()
	{
		float income = 0f;
		for (int i = 0; i < penguins.Count; i++)
		{
			income += penguins[i].getIncomePerSecond();
		}
		return income;
	}
}
