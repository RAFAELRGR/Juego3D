using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiente : MonoBehaviour
{
    public AudioSource ambiente;

    private void Update()
    {
        ambiente.Play();

    }

}
