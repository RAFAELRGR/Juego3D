using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminos : MonoBehaviour
{
    public Transform Player;
    
   void OnTriggerEnter(Collider other)
    {
       if (other.tag == ("Player"))
        {
           gameObject.SetActive(false);

        }
        Debug.Log(other.tag);
    }


    private void Start()
    {
        gameObject.SetActive(true);   
    }
}
