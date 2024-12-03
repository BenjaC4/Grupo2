using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mercado : MonoBehaviour
{
    public GameObject ventanaMercado; // Panel del mercado
    public Inventario inventario; // Referencia al inventario del jugador

    [System.Serializable]
    public class Herramienta
    {
        public string nombre;
        public Sprite icono;
        public int precio;
    }

    public Herramienta[] herramientasDisponibles;
    public GameObject itemPrefab; // Prefab para cada ítem en el catálogo
    public Transform catalogo; // Contenedor para ítems del mercado
    public TMP_Text textoMonedas; // Mostrar monedas disponibles (TextMeshPro)
    public TMP_Text textoDetalles; // Mostrar detalles de la herramienta seleccionada (TextMeshPro)

    private Herramienta herramientaSeleccionada;

    private void Start()
    {
        ActualizarMonedas();
        GenerarCatalogo();
        ventanaMercado.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ventanaMercado.SetActive(!ventanaMercado.activeSelf);
        }
    }

    private void GenerarCatalogo()
    {
        foreach (Herramienta herramienta in herramientasDisponibles)
        {
            GameObject item = Instantiate(itemPrefab, catalogo);

            // Configuración del texto y la imagen usando TMP
            TMP_Text textoNombrePrecio = item.GetComponentInChildren<TMP_Text>();
            if (textoNombrePrecio != null)
            {
                textoNombrePrecio.text = $"{herramienta.nombre}\n{herramienta.precio} monedas";
            }

            Image imagenIcono = item.GetComponentInChildren<Image>();
            if (imagenIcono != null)
            {
                imagenIcono.sprite = herramienta.icono;
            }

            Button boton = item.GetComponentInChildren<Button>();
            if (boton != null)
            {
                boton.onClick.AddListener(() => SeleccionarHerramienta(herramienta));
            }
        }
    }

    private void SeleccionarHerramienta(Herramienta herramienta)
    {
        herramientaSeleccionada = herramienta;
        textoDetalles.text = $"Nombre: {herramienta.nombre}\nPrecio: {herramienta.precio}";
    }

    public void ComprarHerramienta()
    {
        if (herramientaSeleccionada != null)
        {
            if (GameManager.Instancia.RealizarCompra(herramientaSeleccionada.precio))
            {
                inventario.AgregarHerramienta(herramientaSeleccionada.icono);
                ActualizarMonedas();
                textoDetalles.text = "Compra realizada.";
            }
            else
            {
                textoDetalles.text = "Saldo insuficiente.";
            }
        }
    }

    private void ActualizarMonedas()
    {
        textoMonedas.text = $"Monedas: {GameManager.Instancia.monedas}";
    }
}
