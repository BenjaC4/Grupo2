using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearAnimal : MonoBehaviour
{
    public Transform[] puntosDeAparicion; // Puntos donde aparecerán los animales
    public LayerMask capaObstaculos;
    public int nAnimales;
    private int n = 0;
    public GameObject[] prefabsDeAnimales; // Array de prefabs de animales

    void Start()
    {
        while(n<nAnimales){
            GenerarAnimalAleatorio();
            n++;
        }
    }

    void GenerarAnimalAleatorio()
    {
        // Selecciona un prefab de animal aleatorio
        int indiceAleatorio = Random.Range(0, prefabsDeAnimales.Length);
        GameObject prefabSeleccionado = prefabsDeAnimales[indiceAleatorio];

        // Selecciona una posición aleatoria de los puntos de aparición
        int indicePosicionAleatoria = Random.Range(0, puntosDeAparicion.Length);
        Transform puntoDeAparicion = puntosDeAparicion[indicePosicionAleatoria];

        // Verifica que no haya obstáculos en el punto de aparición
        Collider2D colision = Physics2D.OverlapCircle(puntoDeAparicion.position, 0.5f, capaObstaculos);
        if (colision == null)
        {
            // Instancia el animal en la posición aleatoria seleccionada
            Instantiate(prefabSeleccionado, puntoDeAparicion.position, Quaternion.identity);
        }
        else
        {
            // Si hay un obstáculo, puedes intentar buscar otro punto o manejarlo de otra manera
            Debug.Log("Punto de aparición bloqueado por un obstáculo.");
        }
    }
}