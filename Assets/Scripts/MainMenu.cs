using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method loads the game scene.
    public void PlayGame()
    {

        SceneManager.LoadScene("Game");
    }


    public void QuitGame()
    {
   
        Application.Quit();
    }
}
