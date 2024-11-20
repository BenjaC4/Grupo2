using System.Collections.Generic;
using UnityEngine;

public class Agujero2D : MonoBehaviour
{
    // Diccionario para almacenar las posiciones iniciales de los objetos
    private Dictionary<GameObject, Vector2> posicionesIniciales = new Dictionary<GameObject, Vector2>();

    private void Start()
    {
        // Detectar automáticamente todos los objetos con los tags "Animal" y "Jugador"
        RegistrarPosicionesIniciales("Animal");
        RegistrarPosicionesIniciales("Jugador");
    }

    private void RegistrarPosicionesIniciales(string tag)
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objetos)
        {
            if (!posicionesIniciales.ContainsKey(obj))
            {
                posicionesIniciales[obj] = obj.transform.position;
        
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (posicionesIniciales.ContainsKey(other.gameObject))
        {
            // Reiniciar la posición del objeto al valor almacenado
            other.transform.position = posicionesIniciales[other.gameObject];
 
        }
    }
}