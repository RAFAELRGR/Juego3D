using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjetosInventario : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();   
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("Dragging");
        transform.position = Input.mousePosition;    
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);  
        image.raycastTarget = true;
    }

    // Start is called before the first frame update

}
