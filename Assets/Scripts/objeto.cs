using UnityEngine;

public class Objeto : MonoBehaviour
{
    // Este método se ejecuta cuando el objeto entra en contacto con otro objeto con un Collider2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en contacto es el jugador
        if (other.CompareTag("Jugador"))
        {
            // Destruye este objeto
            Destroy(gameObject);
        }
    }
}
