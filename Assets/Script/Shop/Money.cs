using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public static Money instance2;
    public Shop Shop;
    public int money;
    public static bool sendpost3 = false;

    public CollectMoney CollectMoney;

    private void Awake()
    {
        instance2 = this;
    }

    public void Update()
    {
        if(money >= 80 && sendpost3 == false)
        {
            CollectMoney.SendPost();
            sendpost3 = true;
        }
    }

}
