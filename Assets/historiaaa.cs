using UnityEngine;

public class Historiaaa : MonoBehaviour
{
    public GameObject instruccionesPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Cambi� KeyCode.C por KeyCode.G
        {
            instruccionesPanel.SetActive(!instruccionesPanel.activeSelf);
        }
    }
}
