using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventariosSlots : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            ObjetosInventario objetosInventario = eventData.pointerDrag.GetComponent<ObjetosInventario>();
            objetosInventario.parentAfterDrag = transform;
        }


    }
}
