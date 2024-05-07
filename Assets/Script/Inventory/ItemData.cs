using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Items/Item")]

public class ItemData : ScriptableObject
{

    public string description;

    public Sprite thumbnail;

    public GameObject gameModel;

    public bool Stackeable = true;

    public int usestool;

    public string nametool;

    public enum ItemType
    {
        WaterBucket, Pitchfork, Rake, Scythe, Shovel, seed, seed2, seed3, potato
    }

    public ItemType itemType;

}
