using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SingletonAdministradorJuego;
    public static int VelocidadBala=30;
    public static int DisparosPorJuego = 5;
    public static float VelocidadRotacion = 0.1f;

    public GameObject canvasGanar;
    public GameObject canvasPerder;
    public GameObject menuPerder;
    public GameObject menuGanar;
    public Slider slider;

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
        if (DisparosPorJuego <= 0 && !Canon.Bloqueado)
        {
            PerderJuego();
        }
    }

    public void GanarJuego()
    {
        canvasGanar.SetActive(true);
        menuGanar.SetActive(true);
    }

    public void PerderJuego()
    {
        canvasPerder.SetActive(true);
        menuPerder.SetActive(true);
    }

    public void CambiarFuerza()
    {
        VelocidadBala = (int)slider.value;
    }
}
