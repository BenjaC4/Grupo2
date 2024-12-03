using UnityEngine;

public class Historiaaa : MonoBehaviour
{
    public GameObject instruccionesPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Cambié KeyCode.C por KeyCode.G
        {
            instruccionesPanel.SetActive(!instruccionesPanel.activeSelf);
        }
    }
}
