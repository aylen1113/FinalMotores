using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public TextMeshProUGUI healthText;

    //public GameObject gameOverScreen;



    private void Start()
    {
        //gameOverScreen.SetActive(false);
        currentHealth = maxHealth;
        UpdateHealthText();

    }


    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Damage!");
        currentHealth -= damageAmount;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Debug.Log("game over");
            SceneManager.LoadScene("GameOver");


        }
    }
    private void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();  
    }
}
