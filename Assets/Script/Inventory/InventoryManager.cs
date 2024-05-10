using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;

    public int maxStackedItems = 5;
    public InventorySlot[] inventorySlot;
    public GameObject inventoryItemPrefab;
    public GameObject InventoryPanel;
    public bool useitem = false;

    int selectedSlot = -1;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        ChangeSelectedSlot(18);
    }
    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 7)
            {
                ChangeSelectedSlot(number + 17);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventoryPanel();
        }

        if (InventoryPanel.activeSelf == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlot[selectedSlot].Deselect();
        }

        inventorySlot[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(ItemData item)
    {

        for (int i = 0; i < inventorySlot.Length; i++)
        {
            InventorySlot slot = inventorySlot[i];
            InventoryItem iteminSlot = slot.GetComponentInChildren<InventoryItem>();
            if (iteminSlot != null && iteminSlot.ItemData == item && iteminSlot.count < maxStackedItems && item.Stackeable == true)
            {
                iteminSlot.count++;
                iteminSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlot.Length; i++)
        {
            InventorySlot slot = inventorySlot[i];
            InventoryItem iteminSlot = slot.GetComponentInChildren<InventoryItem>();
            if (iteminSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;

    }

    void SpawnNewItem(ItemData item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public void ToggleInventoryPanel()
    {
        InventoryPanel.SetActive(!InventoryPanel.activeSelf);
    }

    public ItemData GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlot[selectedSlot];
        InventoryItem iteminSlot = slot.GetComponentInChildren<InventoryItem>();
        if (iteminSlot != null)
        {
            ItemData itemData = iteminSlot.ItemData;
            if (use == true)
            {
                itemData.usestool -= 1;
                if (itemData.usestool <= 0)
                {
                    iteminSlot.count--;
                    if (iteminSlot.count <= 0)
                    {
                        Destroy(iteminSlot.gameObject);
                    }
                    else
                        iteminSlot.RefreshCount();
                }
            }
            useitem = false;
            return itemData;
        }
        return null;
    }

}