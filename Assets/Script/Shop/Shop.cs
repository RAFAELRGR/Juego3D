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
    public bool confirmsell;

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

    public void detecttype(string nametool)
    {
        if (nametool != null)
        {
            if (InventoryManager.instance.GetSelectedItem(false) != null)
            {
                if (nametool == InventoryManager.instance.GetSelectedItem(false).nametool)
                {
                    confirmsell = true;
                }
                else if (nametool != InventoryManager.instance.GetSelectedItem(false).nametool || nametool == null)
                {
                    confirmsell = false;
                }
            }
        }
    }

    public void sellitem(int value)
    {
        if (confirmsell == true)
        {
            InventoryManager.instance.GetSelectedItem(false).usestool = 1;
            inventoryManager.GetSelectedItem(true);
            Money.instance2.money += value;
        }
        else if (confirmsell == false)
        {
        }
    }
}