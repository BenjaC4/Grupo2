using UnityEngine;

public class Instrucciones : MonoBehaviour
{
    public GameObject instruccionesPanel; // El panel donde se mostrarán las instrucciones

    void Update()
    {
        // Al presionar la tecla "I", abrir o cerrar el panel de instrucciones
        if (Input.GetKeyDown(KeyCode.I))
        {
            instruccionesPanel.SetActive(!instruccionesPanel.activeSelf);
        }
    }
}