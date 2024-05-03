using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public GameObject TiendaUI;
    private bool show = false;

    // Se llama cuando otro objeto entra en el trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.visible = true;
            Debug.Log("¡El jugador está cerca del NPC!");
            show = true;
        }
    }

    // Se llama cuando otro objeto sale del trigger
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El jugador se alejó del NPC!");
            show = false;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        TiendaUI.SetActive(show);
    }
}
