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
        
        if(landStatus == LandStatus.landnormal)
        {
            SwitchLandStatus(LandStatus.land);   
        }else if (landStatus == LandStatus.land)
        {
            SwitchLandStatus(LandStatus.landready);
        }else if (landStatus == LandStatus.landready)
        {
            SwitchLandStatus(LandStatus.landnormal);
        }

    }

}
