using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToolsPlayer : MonoBehaviour
{
    public void Update()
    {
        if(InventoryManager.instance.GetSelectedItem(false))
            showtool(InventoryManager.instance.GetSelectedItem(false).nametool);
    }

    public void showtool(string nametool)
    {
        if (nametool != null)
        {
            foreach (Transform tool in transform)
            {
                if (nametool == tool.name)
                {
                    tool.gameObject.SetActive(true);
                }
                else
                    tool.gameObject.SetActive(false);
            }
        }
    }

}
