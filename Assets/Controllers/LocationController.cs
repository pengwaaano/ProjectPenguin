using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    public List<Location> locations = new List<Location>();
    private Location currentLocation;

    void Awake()
    {
        for (int i = 0; i < locations.Count; i++)
        {
            locations[i].setCapacity(getCapacityForIndex(i));
            locations[i].setCost(getCostForIndex(i));
        }

        loadCurrentLocation();
    }

    private void loadCurrentLocation()
    {
        locations[0].setOwned(true);
        currentLocation = locations[0];
    }

    private float getCostForIndex(int index)
    {
        return Mathf.Pow(index, 10) * 10000;
    }

    private int getCapacityForIndex(int index)
    {
        int cap = GameConstants.penguinCapacityBase;
        for (int i = 0; i < index; i++)
        {
            cap *= (i + 1);
        }
        return cap;
    }

    public int getCurrentCapacity()
    {
        return currentLocation.getCapacity();
    }
}