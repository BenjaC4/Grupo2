using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidadCaminar = 50f;
    public float velocidadCorrer = 80f;
    private Rigidbody2D rb;
    private Vector2 movimiento;

    public float VelocidadActual { get; private set; }

    void Start()
    {
        InicializarJugador();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        CapturarInput();
    }

    void FixedUpdate()
    {
        MoverPersonaje();
    }

    private void InicializarJugador()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void CapturarInput()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");
    }

    private void MoverPersonaje()
    {
        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadCaminar;
        rb.MovePosition(rb.position + movimiento.normalized * velocidadActual * Time.fixedDeltaTime);
    }
}
