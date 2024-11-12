using System.Runtime.CompilerServices;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    private static int nfrutas;
    private CrearObjetoEscondido objeto;

    void Start(){
        objeto = FindAnyObjectByType<CrearObjetoEscondido>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Jugador"))
        {
            objeto.Contarfruta();
            nfrutas = objeto.GetFrutasRecolectadas();
            Debug.Log("Fruta recolectada! Total frutas recolectadas: " + nfrutas);

            Destroy(gameObject);
        }
    }

}

