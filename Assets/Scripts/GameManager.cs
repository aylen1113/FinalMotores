using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int enemyKillCount = 0;
    public int totalEnemies = 10;
    private int enemiesLeft;
    public GameObject victoryCanvas;
    public TextMeshProUGUI enemiesLefttext;
    void Start()
    {
        enemiesLeft = totalEnemies;
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
        }
        UpdateKillCountText();
    }

    // Call this method when an enemy is killed
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
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);

        }
    }

    void UpdateKillCountText()
    {
        if (enemiesLefttext != null)
        {
            enemiesLefttext.text = "Enemies Left: " + enemiesLeft;
        }
    }
}
