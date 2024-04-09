using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    MoveCamera playerController;
    Land selectedLand = null;

    // Start is called before the first frame update
    void Start()
    {

        playerController = transform.parent.GetComponent<MoveCamera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            OnInteractableHit(hit);
        }
    }

    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        var distance = hit.transform.position - playerController.transform.position;

        if (other.tag == "Land" && distance.magnitude <= 4f) 
        {
            Land land = other.GetComponent<Land>();
            SelectLand(land);
            return;
        }

        if(selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }

    }

    void SelectLand(Land land)
    {

        if (selectedLand != null)
        {
            selectedLand.Select(false);
        }

        selectedLand = land;
        land.Select(true);
    }

    public void Interact()
    {
        if (selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }

        Debug.Log("Not on any Ready Land");
    }

}
