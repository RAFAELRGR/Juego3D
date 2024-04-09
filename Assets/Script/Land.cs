using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{

    public enum LandStatus
    {
        land,
        landready
    }

    public LandStatus landStatus;

    public Material landmat, landreadymat;
    new Renderer renderer;
    GameObject select;

    // Start is called before the first frame update
    void Start()
    {
        select = transform.Find("Cube").gameObject;
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(LandStatus.land);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;

        Material materialToSwitch = landmat;

        switch (statusToSwitch)
        {
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
        Debug.Log("Interact");
    }

}
