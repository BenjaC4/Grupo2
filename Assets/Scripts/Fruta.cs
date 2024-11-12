using System.Runtime.CompilerServices;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    // Contador estático de frutas recolectadas accesible desde cualquier parte
    private static int nfrutas;
    private CrearObjetoEscondido objeto;
    private Inventario inventario;

    // Método para obtener el contador de frutas recolectadas
    void Start(){
        objeto = FindAnyObjectByType<CrearObjetoEscondido>();
        inventario = FindAnyObjectByType<Inventario>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en contacto tiene el tag "Jugador"
        if (other.CompareTag("Jugador"))
        {
            // Incrementa el contador de frutas recolectadas
            objeto.Contarfruta();
            nfrutas = objeto.GetFrutasRecolectadas();
            Debug.Log("Fruta recolectada! Total frutas recolectadas: " + nfrutas);

            // Destruye la fruta después de recogerla
            Destroy(gameObject);
        }
    }

}

