using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

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

    }
    public void Ganaste()
    {
        Time.timeScale = 0;
        print("Ganaste");
    }
    private void OnEnable()
    {
        Player.Ganar += Ganaste;
        Player.Perder += Perdiste;
    }
    private void OnDisable()
    {
        Player.Ganar -= Ganaste;
        Player.Perder -= Perdiste;
    }
}
