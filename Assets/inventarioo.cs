using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<GameObject> Bag = new List<GameObject>(); // Lista de ranuras del inventario
    public GameObject inv; // Panel del inventario
    public bool Activar_inv; // Estado de visibilidad del inventario

    public GameObject Selector; // Selector para navegar en el inventario
    public int ID; // Índice de la ranura seleccionada

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Verificar si el objeto tiene el tag "Fruta" (asegúrate de poner este tag a tus frutas)
        if (coll.CompareTag("Fruta"))
        {
            // Obtener el componente Renderer del objeto (esto puede ser un SpriteRenderer o MeshRenderer)
            Renderer itemRenderer = coll.GetComponent<Renderer>();

            if (itemRenderer != null)
            {
                // Recorremos el inventario para buscar una ranura vacía
                for (int i = 0; i < Bag.Count; i++)
                {
                    if (Bag[i].GetComponent<Image>().enabled == false)
                    {
                        // Asignar la textura del material a la ranura del inventario
                        Bag[i].GetComponent<Image>().enabled = true;

                        // Obtener la textura del material del objeto
                        Texture itemTexture = itemRenderer.material.mainTexture;

                        // Asignar la textura a la ranura (aquí convertimos la textura en un sprite solo para mostrarlo)
                        Sprite itemSprite = TextureToSprite(itemTexture); // Convertimos la textura a sprite
                        Bag[i].GetComponent<Image>().sprite = itemSprite;

                        // Desactivar la fruta recogida
                        coll.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
    }

    // Función para convertir una textura a sprite
    private Sprite TextureToSprite(Texture texture)
    {
        return Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public void Navegar()
    {
        if (Input.GetKeyDown(KeyCode.D) && ID < Bag.Count - 1)
        {
            ID++;
        }
        else if (Input.GetKeyDown(KeyCode.A) && ID > 0)
        {
            ID--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && ID >= 4)
        {
            ID -= 4;
        }
        else if (Input.GetKeyDown(KeyCode.S) && ID + 4 < Bag.Count)
        {
            ID += 4;
        }

        // Verificar que ID esté dentro de los límites de Bag antes de acceder a él
        if (ID >= 0 && ID < Bag.Count)
        {
            Selector.transform.position = Bag[ID].transform.position;
        }
    }

    void Update()
    {
        Navegar();

        if (Activar_inv)
        {
            inv.SetActive(true);
        }
        else
        {
            inv.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Activar_inv = !Activar_inv;
        }
    }
}