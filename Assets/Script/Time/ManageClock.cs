using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageClock : MonoBehaviour
{
    public float rotationSpeedMin = 6f; // Grados por segundo
    public float rotationSpeedHor = 0.5f;

    public GameObject Min, Hor;

    public void Test()
    {
        Hor.transform.Rotate(Vector3.forward, rotationSpeedHor * -1 * Time.deltaTime);
        Min.transform.Rotate(Vector3.forward, rotationSpeedMin * -1 * Time.deltaTime);
    }

    private void Update()
    {
        Test();
    }
}
