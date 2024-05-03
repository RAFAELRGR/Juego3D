using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{


    public InventoryManager inventoryManager;
    public bool option;

    public void removemoney(int value)
    {
        if (Money.instance2.money < value)
        {
            option = false;
        }
        else
        {
            Money.instance2.money -= value;
            option = true;
        }

    }

    public void addItem(ItemData itemData)
    {
        if (option == true)
        {
            bool result = InventoryManager.instance.AddItem(itemData);
            if (result == true)
            {
                Debug.Log("Añadio Item");
            }
        }else
            Debug.Log("No hay plata");
    }

    public void sellitem(int value)
    {
        if (inventoryManager.GetSelectedItem(true))
        {
            Money.instance2.money += value;
        }else
        {
            Debug.Log("No hay nada para vender");
        }
    }

}
