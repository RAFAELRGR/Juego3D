using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{

    public enum LandStatus
    {
        land,
        landready,
        landnormal
    }

    public LandStatus landStatus;

    public Material landmat, landreadymat, landnormalmat;
    new Renderer renderer;
    GameObject select;
    public InventoryManager inventoryManager;
    public GameObject flower, seeds, stem;
    public ItemData itemtoPickUp;
    public bool seedaplicated = false;


    // Start is called before the first frame update
    void Start()
    {
        select = transform.Find("Cube").gameObject;
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(landStatus);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;

        Material materialToSwitch = landnormalmat;

        switch (statusToSwitch)
        {
            case LandStatus.landnormal:
                materialToSwitch = landnormalmat;
                break;
            case LandStatus.land:
                materialToSwitch = landmat;
                break;
            case LandStatus.landready:
                materialToSwitch = landreadymat;
                break;
        }

        renderer.material = materialToSwitch;

    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    public void Interact()
    {
        ItemData recievedItem = inventoryManager.GetSelectedItem(false);

        if (recievedItem == null)
        {
            Debug.Log("No hay nada seleccionado");
        }
        else if (landStatus == LandStatus.landnormal && Input.GetKey(KeyCode.F) && recievedItem.itemType == ItemData.ItemType.Scythe)
        {
            SwitchLandStatus(LandStatus.land);
        }

        if (recievedItem.itemType == ItemData.ItemType.seed && Input.GetKey(KeyCode.L))
        {
            seeds = recievedItem.gameModel;
            seedaplicated = true;
            stem.SetActive(true);
        }

        else if (landStatus == LandStatus.land && Input.GetKey(KeyCode.G) && recievedItem.itemType == ItemData.ItemType.WaterBucket && seedaplicated == true)
        {
            SwitchLandStatus(LandStatus.landready);
            stem.SetActive(false);
            flower.SetActive(true);
        }

        else if (landStatus == LandStatus.landready && Input.GetKey(KeyCode.R) && recievedItem.itemType == ItemData.ItemType.Shovel)
        {
            SwitchLandStatus(LandStatus.landnormal);
            flower.SetActive(false);
            var seed = Environment.TickCount;
            var random = new System.Random(seed);
            int repeat = random.Next(1, 5);
            for(int i = 0; i < repeat; i++)
            {
                bool result = InventoryManager.instance.AddItem(itemtoPickUp);
                if (result == true)
                {
                    Debug.Log("Item Añadido");
                }
            }
            seedaplicated = false;
            seeds = null;
        }

    }

}
