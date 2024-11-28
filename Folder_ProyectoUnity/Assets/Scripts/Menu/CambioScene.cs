using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScene : MonoBehaviour
{
    static public void CambiarScene(string escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
