using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public static Money instance2;
    public Shop Shop;
    public int money;

    private void Awake()
    {
        instance2 = this;
    }
}
