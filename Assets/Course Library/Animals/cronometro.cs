using UnityEngine;
using TMPro;
using System.Collections; 

public class Cronometro : MonoBehaviour
{
    private float tiempo; 
    private TextMeshProUGUI textMesh;

    private void Start()
    {

        textMesh = GetComponent<TextMeshProUGUI>();

       
        tiempo = 0;


        StartCoroutine(ContarTiempo());
    }

    private IEnumerator ContarTiempo()
    {
       
        while (true)
        {

            tiempo += Time.deltaTime;

           
            int minutos = Mathf.FloorToInt(tiempo / 60); 
            int segundos = Mathf.FloorToInt(tiempo % 60); 

          
            textMesh.text = $"Tiempo: {minutos:D2}:{segundos:D2}"; 

    
            yield return null;
        }
    }
}

