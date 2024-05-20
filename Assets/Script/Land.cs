using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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

    public int id, timegrow;
    public Material landmat, landreadymat, landnormalmat;
    new Renderer renderer;
    GameObject select;
    public InventoryManager inventoryManager;
    public GameObject flower, seeds, stem;
    public ItemData itemtoPickUp;
    public SeedData seedData;
    public bool seedaplicated;
    public bool scytheuse;
    public static bool sendpost = false;
    public static bool sendpost2 = false;

    public PlantPotatoe PlantPotatoe;
    public HarvestPotatoes HarvestPotatoes;

    void Start()
    {
        select = transform.Find("Cube").gameObject;
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(landStatus);
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
        }
        else if (landStatus == LandStatus.landnormal && Input.GetKey(KeyCode.F) && recievedItem.itemType == ItemData.ItemType.Scythe)
        {
            SwitchLandStatus(LandStatus.land);
            InventoryManager.instance.GetSelectedItem(true);
            scytheuse = true;
        }

        else if (recievedItem.itemType == ItemData.ItemType.seed || recievedItem.itemType == ItemData.ItemType.seed2 || recievedItem.itemType == ItemData.ItemType.seed3)
        {
            if (Input.GetKey(KeyCode.E) && scytheuse == true)
            {
                seedaplicated = true;
                stem.SetActive(true);
                InventoryManager.instance.GetSelectedItem(true);
                FieldInfo[] campos = typeof(SeedData).GetFields(BindingFlags.Public | BindingFlags.Instance);

                foreach (FieldInfo campo in campos)
                {
                    if (campo.Name == "daysToGrow")
                    {
                        timegrow = (int)campo.GetValue(recievedItem);
                    }
                }

                scytheuse = false;

                if(sendpost == false)
                {
                    PlantPotatoe.SendPost();
                    sendpost = true;
                }
            }
        }

        else if (landStatus == LandStatus.land && Input.GetKey(KeyCode.G) && recievedItem.itemType == ItemData.ItemType.WaterBucket && seedaplicated == true)
        {
            InventoryManager.instance.GetSelectedItem(true);
            StartCoroutine(daystogrow(timegrow));
        }

        else if (landStatus == LandStatus.landready && Input.GetKey(KeyCode.R) && recievedItem.itemType == ItemData.ItemType.Shovel)
        {
            SwitchLandStatus(LandStatus.landnormal);
            flower.SetActive(false);
            var seed = Environment.TickCount;
            var random = new System.Random(seed);
            int repeat = random.Next(2, 8);
            for(int i = 0; i < repeat; i++)
            {
                bool result = InventoryManager.instance.AddItem(itemtoPickUp);
                if (result == true)
                {
                }
            }
            seedaplicated = false;
            seeds = null;
            InventoryManager.instance.GetSelectedItem(true);

            if (sendpost2 == false)
            {
                HarvestPotatoes.SendPost();
                sendpost2 = true;
            }
        }

    }

    IEnumerator daystogrow(int grow)
    {
        yield return new WaitForSeconds(grow);
        SwitchLandStatus(LandStatus.landready);
        stem.SetActive(false);
        flower.SetActive(true);
    }

}
