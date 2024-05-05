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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CargarData();
        }
    }
    private void CargarData()
    {
        PlayerData playerdata = SaveManager.LoadPlayerData();
        money = playerdata.money;
        Debug.Log("Datos Cargados");
    }

    private void SaveData()
    {
        SaveManager.savePlayerData(this);
        Debug.Log("Datos Guardados");
    }
}
