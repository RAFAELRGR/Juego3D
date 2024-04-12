using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Tool")]

public class EquipmentData : ItemData
{
    public enum ToolType
    {
        Broom, WaterBucket, Pitchfork, Rake, Scythe, Shovel
    }

    public ToolType toolType;

}
