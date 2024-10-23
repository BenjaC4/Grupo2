using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal : MonoBehaviour
{
private Establo est;

void Start()
{
    est = Object.FindAnyObjectByType<Establo>(); 
}

private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Establo"))
        {
            est.AgregarAnimal(); 
        }
        
    }

}