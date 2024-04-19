using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    public GameObject inventoryPanel;
    public InventariosSlots[] inventorySlots;
    public InventariosSlots[] barSlots;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        RenderInventory();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            ToggleInventoryPanel();
        }

        if (inventoryPanel.activeSelf == true)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

    }

    public void RenderInventory()
    {
        ItemData[] inventoryToolSlots = InventoryManager.Instance.tools;

        RenderInventoryPanel(inventoryToolSlots, inventorySlots);

        ItemData[] BarToolSlots = InventoryManager.Instance.equippedtool;
        if (BarToolSlots != null ) 
        {
            RenderInventoryPanel(BarToolSlots, barSlots);
        }
    }

    void RenderInventoryPanel(ItemData[] slots, InventariosSlots[] uiSlots)
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            uiSlots[i].Display(slots[i]);
        }
    }

    public void ToggleInventoryPanel()
    {

            inventoryPanel.SetActive(!inventoryPanel.activeSelf);

            RenderInventory();

    }

}
