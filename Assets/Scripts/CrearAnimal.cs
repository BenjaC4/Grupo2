using UnityEngine;

public class CrearAnimal : MonoBehaviour
{
    public Transform[] puntosDeAparicion; 
    public LayerMask capaObstaculos;
    public int nAnimales; // Número total de animales a generar
    public GameObject[] prefabsDeAnimales; // Prefabs de animales a generar

    private int n = 0; // Contador de animales generados

    private void Start()
    {
        Debug.Log($"Iniciando generación de {nAnimales} animales...");
        
        // Generar los animales en el inicio
        while (n < nAnimales)
        {
            GenerarAnimalAleatorio();
            n++;
            Debug.Log($"Animal generado: {n}/{nAnimales}");
        }
    }

    private void GenerarAnimalAleatorio()
{
    // Selecciona un prefab de animal aleatorio
    int indiceAleatorio = Random.Range(0, prefabsDeAnimales.Length);
    GameObject prefabSeleccionado = prefabsDeAnimales[indiceAleatorio];

    // Selecciona una posición aleatoria de los puntos de aparición
    int indicePosicionAleatoria = Random.Range(0, puntosDeAparicion.Length);
    Transform puntoDeAparicion = puntosDeAparicion[indicePosicionAleatoria];

    // Verifica que no haya obstáculos en el punto de aparición
    Collider2D colision = Physics2D.OverlapCircle(puntoDeAparicion.position, 0.5f, capaObstaculos);
    if (colision == null)
    {
        // Instancia el animal en la posición seleccionada con la rotación original del prefab
        GameObject nuevoAnimal = Instantiate(prefabSeleccionado, puntoDeAparicion.position, prefabSeleccionado.transform.rotation);

        // Registrar en el GameManager (si lo usas)
        GameManager.Instancia.RegistrarObjeto(nuevoAnimal);

        Debug.Log($"Animal creado en {puntoDeAparicion.position} con rotación {prefabSeleccionado.transform.rotation}");
    }
    else
    {
        Debug.Log("Punto de aparición bloqueado por un obstáculo.");
    }
}
}