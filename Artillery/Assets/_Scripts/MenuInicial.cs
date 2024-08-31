using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public GameObject MenuNiveles;
    public GameObject MenuPrincipal;

    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
        AdministradorJuego.DisparosPorJuego = 5;
    }

    public void SegundoNivel()
    {
        SceneManager.LoadScene(2);
        AdministradorJuego.DisparosPorJuego = 5;
    }

    public void TercerNivel()
    {
        SceneManager.LoadScene(3);
        AdministradorJuego.DisparosPorJuego = 5;
    }

    public void CuartoNivel()
    {
        SceneManager.LoadScene(4);
        AdministradorJuego.DisparosPorJuego = 5;
    }

    public void FinalizarJuego()
    {
        Application.Quit();
    }

    public void MostrarNiveles()
    {
        MenuPrincipal.SetActive(false);
        MenuNiveles.SetActive(true);
    }

    public void MostrarMenuInicial()
    {
        MenuPrincipal.SetActive(true);
        MenuNiveles.SetActive(false);
    }

}
