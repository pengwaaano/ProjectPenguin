using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;

public class PopulateList : MonoBehaviour
{
    public ListItemEnums listItemType;
    public RectTransform scrollContent;
    public GameObject listItem;

    private void Start()
    {
        if (listItemType == ListItemEnums.LocationListItem)
        {
            List<Location> listData = Camera.main.gameObject.GetComponent<LocationController>().locations;
            foreach (var location in listData)
            {
                instantiateLocationItem(location);
            }
        }
        else if (listItemType == ListItemEnums.PenguinListItem)
        {
            List<Penguin> listData = Camera.main.gameObject.GetComponent<PenguinController>().penguins;
            foreach (var penguin in listData)
            {
                instantiatePenguinItem(penguin);
            }
        }
    }

    private void instantiateLocationItem(Location location)
    {
        GameObject newItem = Instantiate(listItem);
        newItem.transform.SetParent(scrollContent);
        newItem.GetComponent<LocationListItem>().populateViews(location);
    }
    
    private void instantiatePenguinItem(Penguin penguin)
    {
        GameObject newItem = Instantiate(listItem);
        newItem.transform.SetParent(scrollContent);
        newItem.GetComponent<PenguinListItem>().populateViews(penguin);
    }
}