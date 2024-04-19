using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true;
    }

        public void EmpezarJuego(string nivel)
    {
        SceneManager.LoadScene(nivel);  
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Se Cierra el Juego");
    }
}
