using UnityEngine;
using TMPro; 
public class ContadorAnimales : MonoBehaviour
{
    private Establo est; 
    private TextMeshProUGUI textMesh; 

    void Start()
    {
        est = FindFirstObjectByType<Establo>();

        textMesh = GetComponent<TextMeshProUGUI>();

        if (est == null)
        {
            Debug.LogError("No se encontró un objeto de tipo Establo en la escena.");
        }
    }

    void Update()
    {
    
        if (est != null)
        {
            textMesh.text = $"{est.totalAnimales}/{est.maxAnimales}";
        }
    }
}
