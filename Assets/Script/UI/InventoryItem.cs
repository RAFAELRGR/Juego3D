using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{ 
    public Image image;
    public Text countText;
    
    [HideInInspector] public ItemData ItemData;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int count = 1;

    public void InitialiseItem(ItemData itemData)
    {
        if (itemData.itemType != ItemData.ItemType.potato && itemData.itemType != ItemData.ItemType.seed && itemData.itemType != ItemData.ItemType.seed2 && itemData.itemType != ItemData.ItemType.seed3)
            ItemData = Instantiate(itemData);
        else
            ItemData = itemData;
        image.sprite = itemData.thumbnail;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

}
