using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dollars : MonoBehaviour
{

    public Money money;
    public Text Text;

    private void Update()
    {
        int playermoney = money.money;
        Text.text = playermoney.ToString();
    }

}
