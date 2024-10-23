using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Establo : MonoBehaviour
{

    public int totalAnimales = 0;
    public int maxAnimales = 20;

    public void AgregarAnimal()
    {
        if(totalAnimales<maxAnimales){
            totalAnimales++;  
            }
    }
    
}