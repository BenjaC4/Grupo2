using UnityEngine;

public class ListaObjetos : MonoBehaviour
{
    public GameObject instruccionesPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Cambié KeyCode.I por KeyCode.C
        {
            instruccionesPanel.SetActive(!instruccionesPanel.activeSelf);
        }
    }
}