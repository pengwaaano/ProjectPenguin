using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ListItemEnums
{
    LocationListItem, PenguinListItem
}

public enum UpgradableAttributes
{
    FishPerPenguin, FishPerSecond
}

public enum Unit
{
    Percent, Whole
}

public class GameConstants {
    public static readonly float fishPerPenguinBase = 0.025f;
    public static readonly int penguinCapacityBase = 250;
}

public class StringConstants
{
    public static readonly String fishPerPenguin = "Fish per Penguin";
    public static readonly String fishPerSecond = "Fish per Second";
}
