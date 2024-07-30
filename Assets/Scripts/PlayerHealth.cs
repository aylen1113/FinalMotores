using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    //public HealthBar healthBar;

    public GameObject gameOverScreen;



    private void Start()
    {
        gameOverScreen.SetActive(false);
        currentHealth = maxHealth;


    }


    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Damage!");
        currentHealth -= damageAmount;
        //healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("game over");
            gameOverScreen.SetActive(true);

        }
    }
}