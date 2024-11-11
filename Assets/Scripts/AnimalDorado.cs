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

    }
    void Update(){
        if (haAparecido == false){
        AparecerAnimalDorado();
        }
    }


    public void AparecerAnimalDorado()
    {
        if(est.maxAnimales == est. totalAnimales){

            Debug.Log("A aparecido el animal dorado");
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
    }
}

