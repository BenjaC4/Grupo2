using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }
    public int monedas = 100; // Monedas iniciales del jugador

    private Dictionary<GameObject, Vector2> posicionesIniciales = new Dictionary<GameObject, Vector2>();
    private int nivelActual = 1;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        RegistrarObjetosPorTag("Animal");
        RegistrarObjetosPorTag("Jugador");
    }

    public void RegistrarObjeto(GameObject obj)
    {
        if (!posicionesIniciales.ContainsKey(obj))
        {
            posicionesIniciales[obj] = obj.transform.position;
        }
    }

    public void RegistrarObjetosPorTag(string tag)
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objetos)
        {
            RegistrarObjeto(obj);
        }
    }

    public bool ReiniciarObjeto(GameObject obj)
    {
        if (posicionesIniciales.ContainsKey(obj))
        {
            obj.transform.position = posicionesIniciales[obj];
            return true;
        }
        return false;
    }

    public void CargarSiguienteNivel()
    {
        posicionesIniciales.Clear();
        nivelActual++;
        if (nivelActual <= 8)
        {
            SceneManager.LoadScene($"nivel{nivelActual}");
        }
        else
        {
            Debug.Log("¡No hay más niveles! Juego completado.");
        }
    }

    public bool RealizarCompra(int costo)
    {
        if (monedas >= costo)
        {
            monedas -= costo;
            return true;
        }
        return false;
    }

    public void AñadirMonedas(int cantidad)
    {
        monedas += cantidad;
    }

    public int ObtenerNivelActual()
    {
        return nivelActual;
    }
}
