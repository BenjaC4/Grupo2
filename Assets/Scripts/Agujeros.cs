using UnityEngine;

public class Agujero2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.Instancia.ReiniciarObjeto(other.gameObject))
        {
            Debug.Log("El objeto no está registrado: " + other.gameObject.name);
        }
    }
}