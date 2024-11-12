using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float fuerzaEmpuje = 5f;  
    private Rigidbody2D rb;
    private bool puedeSerEmpujado = true;  
    private float factorVelocidad = 0.75f; 

    private Jugador jugador;  

    
    void Start()
    {
        InicializarAnimal();
        //busca al objeto jugador
        jugador = Object.FindAnyObjectByType<Jugador>(); 
    }

    void FixedUpdate()
    {
        if (!puedeSerEmpujado) return; 
    }

    private void InicializarAnimal()
    {
        //hace que el animal no se caiga del mapa, ademas hace que el eje z deje de rotar por temas de animacion
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;  
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;  
    }

    public void Empujar(Vector2 direccionEmpuje)
    {
        if (puedeSerEmpujado && jugador != null && jugador.CompareTag("Jugador"))
        {
           
            float velocidadJugador = jugador.VelocidadActual;
            //El animal tanto como jugador se mueven a un 75% de la velocidad del jugador sin empujar
            float velocidadAnimal = velocidadJugador * factorVelocidad;

            Vector2 movimiento = direccionEmpuje.normalized * fuerzaEmpuje * velocidadAnimal;
            rb.linearVelocity = movimiento;
        }
    }


    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Establo"))
        {
            DesaparecerEnEstablo(); 
        }
        
    }

    private void DesaparecerEnEstablo()
    {
        //Elimina el objeto al hacer contacto con establo
        puedeSerEmpujado = false;  
        rb.linearVelocity = Vector2.zero;  
        Destroy(gameObject); 
    }


    private void OnCollisionStay2D(Collision2D colision)
    {
        //Esta linea fue agregada para que el objeto al dejar de ser empujado se detenga
            rb.linearVelocity = Vector2.zero;  
    }
}