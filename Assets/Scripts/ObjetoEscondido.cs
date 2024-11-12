using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearObjetoEscondido : MonoBehaviour
{
    private static int frutasRecolectadas = 0;
    public Transform[] puntosDeAparicion; 
    public LayerMask capaObstaculos;
    public int nObjetos;
    private int n = 0;
    public GameObject[] prefabsDeObjetos;

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
        int indiceAleatorio = Random.Range(0, prefabsDeObjetos.Length);
        GameObject prefabSeleccionado = prefabsDeObjetos[indiceAleatorio];

        int indicePosicionAleatoria = Random.Range(0, puntosDeAparicion.Length);
        Transform puntoDeAparicion = puntosDeAparicion[indicePosicionAleatoria];

        Collider2D colision = Physics2D.OverlapCircle(puntoDeAparicion.position, 0.5f, capaObstaculos);
        if (colision == null)
        {
            GameObject objetoEscondido = Instantiate(prefabSeleccionado, puntoDeAparicion.position, Quaternion.identity);

            objetoEscondido.transform.localScale *= 0.4f;
        }
        else
        {
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