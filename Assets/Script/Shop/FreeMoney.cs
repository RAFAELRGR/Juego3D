using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Land;
using static UnityEditor.Progress;

public class FreeMoney : MonoBehaviour
{

    public Money Money;
    public NpcInteraction Interaction;
    public int freemoney = 0;
    public Text Text;
    private bool puedeejecutarse = true;

    private void OnTriggerEnter(Collider other)
    {
        if (puedeejecutarse)
        {
            Freemoney();
            StartCoroutine(EsperarParaRepetir());
        }
    }

    public void Freemoney()
    {
        if (Interaction.show == true)
        {
            var seed = Environment.TickCount;
            var random = new System.Random(seed);
            int repeat = random.Next(10, 25);
            for (int i = 0; i < repeat; i++)
            {
                freemoney += 1;
            }
            Money.money += freemoney;

            Text.text = freemoney.ToString();
        }
        freemoney = 0;
        puedeejecutarse = false;
    }

    private IEnumerator EsperarParaRepetir()
    {
        yield return new WaitForSeconds(180f);
        puedeejecutarse = true;
    }

}
