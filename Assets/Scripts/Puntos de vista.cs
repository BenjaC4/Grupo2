using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class Puntodevista : MonoBehaviour
{
    private Canvas hud;
    public CinemachineCamera camIsometric;
    public CinemachineCamera camTopView;
    public CinemachineCamera camIsometricZoom;

    private CinemachineCamera[] cameras;
    private int CamaraActual = 0;
    public float hudDistance = 10f;

    void Start()
    {
        //Encuentra el hud para poder utilizarlo
        hud = FindAnyObjectByType<Canvas>();
        //En la lista tipo CinemachineCamera creo 3 camaras tipo Cinemachinecamera
        //Estas camaras deben ser seleccionadadas desde el editor de Unity
        cameras = new CinemachineCamera[] { camIsometric, camTopView, camIsometricZoom };
        
        CambioCamara(0);
        FijarHUDCamera(); 
    }

    void Update()
    {
        //Espera el input de la tecla v para cambiar las camaras
        if (Input.GetKeyDown(KeyCode.V))
        {
            //Recorre la lista de cameras
            CamaraActual = (CamaraActual + 1) % cameras.Length;
            CambioCamara(CamaraActual);
            FijarHUDCamera(); 
        }
    }

    void CambioCamara(int n)
    {
        //Cambia las prioridades de las camaras y asi pone la seleccionada a la vista
        foreach (var cam in cameras)
        {
            cam.Priority = 0;
        }
        cameras[n].Priority = 1;
    }

    void FijarHUDCamera()
    {

        if (hud != null)
        {
            //Con estas lineas de codigo hacemos que el hud se fije en la camara actual
            Camera mainCamera = Camera.main;
            hud.worldCamera = mainCamera;
            hud.planeDistance = hudDistance;
        }
    }
}
