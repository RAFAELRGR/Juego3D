using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public ItemData itemToPickup;
    public GameObject GameObject;
    public CapsuleCollider capsuleCollider;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool result = InventoryManager.instance.AddItem(itemToPickup);
            if (result == true)
            {
                Destroy(capsuleCollider);
                Destroy(GameObject);
            }
        }
    }
}
