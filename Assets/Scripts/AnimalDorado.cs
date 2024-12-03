using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDorado : MonoBehaviour
{
    public Transform puntoDeAparicion;
    public Transform establo;
    private bool haAparecido = false;

    private Rigidbody2D rb;
    private Establo est;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        est = Object.FindAnyObjectByType<Establo>();

        // Buscar automáticamente el punto de aparición con el tag "punto_aparicion"
        GameObject puntoAparicionObj = GameObject.FindGameObjectWithTag("punto_aparicion");
        if (puntoAparicionObj != null)
        {
            puntoDeAparicion = puntoAparicionObj.transform;
        }
        else
        {
            Debug.LogError("No se encontró un objeto con el tag 'punto_aparicion'");
        }
    }

    void Update()
    {
        if (!haAparecido)
        {
            AparecerAnimalDorado();
        }
    }

    public void AparecerAnimalDorado()
    {
        if (est.maxAnimales - 1 == est.totalAnimales)
        {
            Debug.Log("Ha aparecido el animal dorado");
            transform.position = puntoDeAparicion.position;
            haAparecido = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Establo"))
        {
            LLegarAlEstablo();
        }
    }

    public void LLegarAlEstablo()
    {
        FinalizarRonda();
    }

    public void FinalizarRonda()
    {
        Debug.Log("¡Ronda Finalizada! Has llevado al animal dorado al establo.");
        GameManager.Instancia.CargarSiguienteNivel();
    }
}