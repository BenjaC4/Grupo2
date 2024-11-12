using UnityEngine;

public class Instrucciones : MonoBehaviour
{
    public GameObject instruccionesPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            instruccionesPanel.SetActive(!instruccionesPanel.activeSelf);
        }
    }
}