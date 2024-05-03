using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{


    public InventoryManager inventoryManager;
    public bool option;
    public GameObject NohayPlata;
    public GameObject ConfirmacionCompra;
    public bool selecteditem;

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
                ConfirmacionCompra.SetActive(true);
            }
        }
        else
        {
            NohayPlata.SetActive(true);
        }
    }

    public void detecttype(ItemData itemType)
    {
        if (itemType == inventoryManager.GetSelectedItem(false))
        {
            selecteditem = true;
        }
        else
        {
            selecteditem = false;
        }
    }

    public void sellitem(int value)
    {
        if (inventoryManager.GetSelectedItem(false) && selecteditem == true)
        {
            inventoryManager.GetSelectedItem(true);
            Money.instance2.money += value;
        }else
        {
        }
    }

}
