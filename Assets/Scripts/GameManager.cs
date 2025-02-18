using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyKillCount = 0;
    public int totalEnemies = 10;
    private int enemiesLeft;
    //public GameObject victoryCanvas;
    public TextMeshProUGUI enemiesLefttext;
    void Start()
    {
        enemiesLeft = totalEnemies;
     
        UpdateKillCountText();
    }


    public void EnemyKilled()
    {
        enemiesLeft--;
        UpdateKillCountText();
        if (enemiesLeft <= 0)
        {
            ShowVictoryCanvas();
        }
    }

    void ShowVictoryCanvas()
    {
      
            SceneManager.LoadScene("Victory");
         
        
    }

    void UpdateKillCountText()
    {
        if (enemiesLefttext != null)
        {
            enemiesLefttext.text = "Enemies Left: " + enemiesLeft;
        }
    }
}
