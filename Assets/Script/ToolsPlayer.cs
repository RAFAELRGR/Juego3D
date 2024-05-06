using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToolsPlayer : MonoBehaviour
{
    public void Update()
    {
        if (InventoryManager.instance.GetSelectedItem(false) != null)
            showtool(InventoryManager.instance.GetSelectedItem(false).nametool);
        else
            showtool("");

    }

    public void showtool(string nametool)
    {
        foreach (Transform tool in transform)
        {
            if (nametool == tool.name)
            {
                tool.gameObject.SetActive(true);
            }

            else if (nametool != tool.name)
            {
                tool.gameObject.SetActive(false);
            }
        }
    }
}