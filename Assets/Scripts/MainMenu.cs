using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject victoryCanvas;
    //public GameObject gameOverCanvas;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
    
        SceneManager.LoadScene("Game"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Time.timeScale = 1f;
    }
}
