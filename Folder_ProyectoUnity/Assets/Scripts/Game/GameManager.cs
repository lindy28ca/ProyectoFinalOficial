using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
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
}
