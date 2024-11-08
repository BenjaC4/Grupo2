using UnityEngine;
using TMPro;
using System.Collections; 

public class Cronometro : MonoBehaviour
{
    private float tiempo; 
    private TextMeshProUGUI textMesh;
    private Establo est;
    private Coroutine tiempoC;

    private void Start()
    {

        textMesh = GetComponent<TextMeshProUGUI>();
        est = Object.FindAnyObjectByType<Establo>(); 
        tiempo = 0;
        tiempoC = StartCoroutine(ContarTiempo());
    }
    private void Update(){
        if(est.maxAnimales == est. totalAnimales){
           StopCoroutine(tiempoC);

        }
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

