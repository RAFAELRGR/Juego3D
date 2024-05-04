using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToolsPlayer : MonoBehaviour
{

    public ShowItems[] ShowItems;

    public void Update()
    {
        for (int i = 0; i < ShowItems.Length; i++)
        {
                ShowItems[i].showitem();
        }
    }

}
