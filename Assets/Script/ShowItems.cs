using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItems : MonoBehaviour
{
    public ItemData ItemData;
    public GameObject tool;
    public InventoryManager inventoryManager;
    public bool toolactive;

    public void showitem()
    {
        toolactive = false;
        if (toolactive == false)
        {
            if (ItemData == inventoryManager.GetSelectedItem(false))
            {
                tool.SetActive(true);
            }
            else
            {
                tool.SetActive(false);
            }
        }
    }
}
