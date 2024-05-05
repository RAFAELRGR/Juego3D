using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool pausa = false;
    public GameObject MenuSalir;
    public GameObject PlayerInteraction;
    public AudioSource aves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
                pausa =true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                PlayerInteraction.SetActive(false);
                aves.Pause();
            }
            else if (pausa == true)
            {
                Reanudar();
            }
        }
    }



    public void Reanudar()
    {
        ObjetoMenuPausa.SetActive(false);
        MenuSalir.SetActive(false);

        pausa = false;

        Debug.Log("ReanudarJuego() llamado.");

        

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        aves.Play();

        PlayerInteraction.SetActive(true);
    }

    public void IrMenuPrincipal(string Menu) 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Menu);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Se Cierra el Juego");
    }
}
