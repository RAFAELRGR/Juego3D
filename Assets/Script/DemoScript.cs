using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{

    public InventoryManager inventoryManager;
    public ItemData[] itemToPickup;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemToPickup[id]);
        if (result == true)
        {
            Debug.Log("Hay espacio");
        }
        else
            Debug.Log("No hay espacio");
    }


    public void GetSelectedItem()
    {
        ItemData recievedItem = inventoryManager.GetSelectedItem(false);
        if (recievedItem != null)
        {
            Debug.Log("Se recibio el item" + recievedItem);
        }
        else
            Debug.Log("No hay item para recibir");
    }
    public void UseSelectedItem()
    {
        ItemData recievedItem = inventoryManager.GetSelectedItem(true);
        if (recievedItem != null)
        {
            Debug.Log("Se uso el item" + recievedItem);
        }
        else
            Debug.Log("No hay item para usar");
    }

}
