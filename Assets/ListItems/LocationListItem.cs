using Classes;
using UnityEngine;
using UnityEngine.UI;

public class LocationListItem : MonoBehaviour
{
    public Image locationImage;
    public Text locationTitle;
    public Text locationSubtext;
    public Button locationBuyButton;
    public Text locationBuyButtonText;

    public void populateViews(Location location)
    {
        locationTitle.text = location.name;
        locationSubtext.text = location.description;
        if (location.isOwned())
        {
            locationBuyButton.enabled = false;
            locationBuyButtonText.text = "Owned";
        }
        else
        {
            locationBuyButtonText.text = location.getCost() + "F";
        }
    }
}