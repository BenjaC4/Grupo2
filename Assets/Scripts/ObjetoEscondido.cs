using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearObjetoEscondido : MonoBehaviour
{
    private static int frutasRecolectadas = 0;
    public Transform[] puntosDeAparicion; // Puntos donde aparecerán las frutas
    public LayerMask capaObstaculos;
    public int nObjetos;
    private int n = 0;
    public GameObject[] prefabsDeObjetos; // Array de prefabs de frutas

    void Start()
    {
        while (n < nObjetos)
        {
            GenerarObjetoEscondido();
            n++;
        }
    }

    void GenerarObjetoEscondido()
    {
        // Selecciona un prefab de objeto aleatorio
        int indiceAleatorio = Random.Range(0, prefabsDeObjetos.Length);
        GameObject prefabSeleccionado = prefabsDeObjetos[indiceAleatorio];

        // Selecciona una posición aleatoria de los puntos de aparición
        int indicePosicionAleatoria = Random.Range(0, puntosDeAparicion.Length);
        Transform puntoDeAparicion = puntosDeAparicion[indicePosicionAleatoria];

        // Verifica que no haya obstáculos en el punto de aparición
        Collider2D colision = Physics2D.OverlapCircle(puntoDeAparicion.position, 0.5f, capaObstaculos);
        if (colision == null)
        {
            // Instancia el objeto en la posición aleatoria seleccionada y lo hace "menos visible"
            GameObject objetoEscondido = Instantiate(prefabSeleccionado, puntoDeAparicion.position, Quaternion.identity);

            // Puedes también reducir ligeramente el tamaño para que sea menos visible
            objetoEscondido.transform.localScale *= 0.4f;
        }
        else
        {
            // Si hay un obstáculo, intenta otro punto o maneja esto de otra manera
            Debug.Log("Punto de aparición bloqueado por un obstáculo.");
        }
    }

    public int GetFrutasRecolectadas()
    {
        return frutasRecolectadas;
    }

    public void Contarfruta()
    {
            frutasRecolectadas++;       
    }

}