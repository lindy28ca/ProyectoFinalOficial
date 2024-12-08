using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject perdiste;
    public GameObject ganaste;
    private void Start()
    {
        Reanudar();
    }
    public void Pausa()
    {
        Time.timeScale = 0.0f;
    }
    public void Reanudar()
    {
        Time.timeScale = 1.0f;
    }
    public void CargarScena(string scena)
    {
        SceneManager.LoadScene(scena);
    }
    public void Perdiste()
    {
        perdiste.SetActive(true);
        Pausa();

    }
    public void Ganaste()
    {
        ganaste.SetActive(true);
        Pausa();
    }
    private void OnEnable()
    {
        Player.Ganar += Ganaste;
        Player.Perder += Perdiste;
        Temporizador.Perder += Perdiste;
    }
    private void OnDisable()
    {
        Player.Ganar -= Ganaste;
        Player.Perder -= Perdiste;
        Temporizador.Perder -= Perdiste;
    }
}
