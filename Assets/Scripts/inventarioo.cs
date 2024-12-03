using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inv;
    public bool Activar_inv;

    public GameObject Selector;
    public int ID;

    public void AgregarHerramienta(Sprite icono)
    {
        for (int i = 0; i < Bag.Count; i++)
        {
            if (!Bag[i].GetComponent<Image>().enabled)
            {
                Bag[i].GetComponent<Image>().enabled = true;
                Bag[i].GetComponent<Image>().sprite = icono;
                break;
            }
        }
    }

    public void Navegar()
    {
        if (Input.GetKeyDown(KeyCode.D) && ID < Bag.Count - 1) ID++;
        else if (Input.GetKeyDown(KeyCode.A) && ID > 0) ID--;
        else if (Input.GetKeyDown(KeyCode.W) && ID >= 4) ID -= 4;
        else if (Input.GetKeyDown(KeyCode.S) && ID + 4 < Bag.Count) ID += 4;

        Selector.transform.position = Bag[ID].transform.position;
    }

    private void Update()
    {
        Navegar();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Activar_inv = !Activar_inv;
            inv.SetActive(Activar_inv);
        }
    }
}
