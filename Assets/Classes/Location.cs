using System;
using UnityEngine;
using UnityEngine.UI;

namespace Classes
{
    [Serializable]
    public class Location
    {
        public string name;
        public string description;
        private int capacity;
        private float cost;
        private bool owned;

        public int getCapacity()
        {
            return capacity;
        }

        public void setCapacity(int c)
        {
            capacity = c;
        }

        public float getCost()
        {
            return cost;
        }

        public void setCost(float f)
        {
            cost = f;
        }

        public void setOwned(bool b)
        {
            owned = b;
        }

        public bool isOwned()
        {
            return owned;
        }
    }

    public class LocationViewHolder : RecyclerView.ViewHolder
    {
        private Image locationImage;
        private Text locationTitle;
        private Text locationSubtext;
        private Button locationBuyButton;
        private Text locationBuyButtonText;

        public LocationViewHolder(GameObject itemView) : base(itemView)
        {
            locationImage = itemView.transform.Find("ListItemImage").GetComponent<Image>();
            locationTitle = itemView.transform.Find("Title").GetComponent<Text>();
            locationSubtext = itemView.transform.Find("Subtext").GetComponent<Text>();
        }
    }
}