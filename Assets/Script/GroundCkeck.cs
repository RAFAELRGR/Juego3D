using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Transform player;
    Vector3 distance;
    void Start()
    {
        distance = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + distance;
    }
}
