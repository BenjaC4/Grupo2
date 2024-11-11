using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonajeSecundario2D : MonoBehaviour
{
    public Transform[] rutaPuntos;
    public float velocidad = 2f;
    public float distanciaCambioPunto = 0.2f;
    public LayerMask capaObstaculos;
    private int puntoActual = 0;
    private bool estaPausado = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!estaPausado)
        {
            MoverSecundario();
        }
    }

    void MoverSecundario()
    {
        if (rutaPuntos.Length == 0) return;

        Transform objetivo = rutaPuntos[puntoActual];
        Vector2 direccion = (objetivo.position - transform.position).normalized;
        rb.MovePosition(rb.position + direccion * velocidad * Time.deltaTime);

        if (DetectarColision(direccion))
        {
            AjustarRuta();
        }

        if (Vector2.Distance(transform.position, objetivo.position) < distanciaCambioPunto)
        {
            puntoActual = (puntoActual + 1) % rutaPuntos.Length;
        }
    }

    bool DetectarColision(Vector2 direccion)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, distanciaCambioPunto, capaObstaculos);
        return hit.collider != null;
    }

    void AjustarRuta()
    {
        estaPausado = true;
        puntoActual = (puntoActual + 1) % rutaPuntos.Length;
        Invoke("ReanudarMovimiento", 1f);
    }

    void ReanudarMovimiento()
    {
        estaPausado = false;
    }
}
//
