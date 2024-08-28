using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SingletonAdministradorJuego;
    public static int VelocidadBala = 30;
    public static int DisparosPorJuego = 10;
    public static float VelocidadRotacion = 1;

    public GameObject canvasGanar;
    public GameObject canvasPerder;

    private void Awake()
    {
        if (SingletonAdministradorJuego == null)
        {
            SingletonAdministradorJuego = this;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }

    }

    private void Update()
    {
        if (DisparosPorJuego < 0 && !Canon.Bloqueado)
        {
            PerderJuego();
        }
    }

    public void GanarJuego()
    {
        canvasGanar.SetActive(true);
    }

    public void PerderJuego()
    {
        canvasPerder.SetActive(true);
    }
}
