using UnityEngine;
using TMPro;
using System.Collections; 

public class Cronometro : MonoBehaviour
{
    private float tiempo; 
    private TextMeshProUGUI textMesh;
    private Establo est;
    private Coroutine tiempoC;
    private CrearObjetoEscondido Oescondido;
    private bool detenido = false;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        est = Object.FindAnyObjectByType<Establo>(); 
        Oescondido = FindAnyObjectByType<CrearObjetoEscondido>(); // Referencia a Oescondido
        tiempo = 0;
        tiempoC = StartCoroutine(ContarTiempo());
    }

    private void Update()
    {
        if (est.maxAnimales == est.totalAnimales && !detenido)
        {
            detenido = true;
            StopCoroutine(tiempoC);
            AplicarDescuento();
        }
    }

    private void AplicarDescuento()
    {
        int frutasRecolectadas = Oescondido.GetFrutasRecolectadas();
        float descuento = frutasRecolectadas * 5; 
        tiempo = Mathf.Max(0, tiempo - descuento);
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        textMesh.text = $"Tiempo: {minutos:D2}:{segundos:D2}";

        Debug.Log($"Descuento aplicado: -{descuento} segundos por {frutasRecolectadas} frutas recolectadas.");
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

