using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventariosSlots : MonoBehaviour, IDropHandler
{

    ItemData itemToDisplay;

    public Image itemDisplayImage;

    public void Display(ItemData itemToDisplay)
    {
        if (itemToDisplay != null && itemToDisplay.thumbnail != null)
        {
            itemDisplayImage.sprite = itemToDisplay.thumbnail;
            this.itemToDisplay = itemToDisplay;
            itemDisplayImage.gameObject.SetActive(true);
        }
        else
        {
            itemDisplayImage.gameObject.SetActive(false);
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
          ObjetosInventario objetosInventario = eventData.pointerDrag.GetComponent<ObjetosInventario>();
          //objetosInventario.parentAfterDrag = transform.parent;
          objetosInventario.transform.SetParent(transform);
          Debug.Log(transform);
        }

    }


}
