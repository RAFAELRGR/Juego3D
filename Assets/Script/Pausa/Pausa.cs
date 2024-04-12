using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool pausa = false;
    public GameObject PlayerInteraction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
                pausa =true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                PlayerInteraction.SetActive(false);
            }
        }
    }



    public void Reanudar()
    {
        ObjetoMenuPausa.SetActive(false);
        pausa = false;

        Debug.Log("ReanudarJuego() llamado.");

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        PlayerInteraction.SetActive(true);
    }
}
