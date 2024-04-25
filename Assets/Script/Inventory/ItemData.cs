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

}
