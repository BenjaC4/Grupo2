using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Establo : MonoBehaviour
{

    public int totalAnimales = 0;
    public int maxAnimales;

    public void Start()
    {
        GameObject[] animales = GameObject.FindGameObjectsWithTag("Animal");
        maxAnimales = animales.Length;
    }
    public void AgregarAnimal()
    {
        if(totalAnimales<maxAnimales){
            totalAnimales++;  
            }
    }
    
}