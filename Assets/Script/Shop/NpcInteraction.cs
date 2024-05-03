using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public GameObject TiendaUI;
    private bool show = false;
    public MoveCamera move;

    // Se llama cuando otro objeto entra en el trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            move.enabled = false;
            show = true;

        }
    }

    // Se llama cuando otro objeto sale del trigger
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            show = false;
            move.enabled=true;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        TiendaUI.SetActive(show);
    }
}
