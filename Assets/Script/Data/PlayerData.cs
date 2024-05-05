using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int money;
    public float[] position = new float[3];

    public PlayerData(Money moneys)
    {
        money = moneys.money;
    }

    public PlayerData(Move move)
    {
        position[0] = move.transform.position.x;
        position[1] = move.transform.position.y;
        position[2] = move.transform.position.z;
    }
}
