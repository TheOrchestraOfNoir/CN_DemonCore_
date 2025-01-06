using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    // Player 1 health and UI references
    public Image playerOneHealthBar;
    public float playerOneHealth = 100f;

    // Player 2 health and UI references
    public Image playerTwoHealthBar;
    public float playerTwoHealth = 100f;

    // Update is called once per frame
    void Update()
    {
        // Check if either player's health is zero or below
        if (playerOneHealth <= 0 || playerTwoHealth <= 0)
        {
            // Reload the scene when either player loses
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Controls for Player 1
        if (Input.GetKeyDown(KeyCode.Q)) // Player 1 takes damage
        {
            PlayerOneTakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.W)) // Player 1 heals
        {
            PlayerOneHeal(5);
        }

        // Controls for Player 2
        if (Input.GetKeyDown(KeyCode.O)) // Player 2 takes damage
        {
            PlayerTwoTakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.P)) // Player 2 heals
        {
            PlayerTwoHeal(5);
        }
    }

    // Player 1 damage handling
    public void PlayerOneTakeDamage(float damage)
    {
        playerOneHealth -= damage;
        playerOneHealth = Mathf.Clamp(playerOneHealth, 0, 100);
        UpdateHealthBar(playerOneHealthBar, playerOneHealth);
    }

    // Player 1 healing
    public void PlayerOneHeal(float healingAmount)
    {
        playerOneHealth += healingAmount;
        playerOneHealth = Mathf.Clamp(playerOneHealth, 0, 100);
        UpdateHealthBar(playerOneHealthBar, playerOneHealth);
    }

    // Player 2 damage handling
    public void PlayerTwoTakeDamage(float damage)
    {
        playerTwoHealth -= damage;
        playerTwoHealth = Mathf.Clamp(playerTwoHealth, 0, 100);
        UpdateHealthBar(playerTwoHealthBar, playerTwoHealth);
    }

    // Player 2 healing
    public void PlayerTwoHeal(float healingAmount)
    {
        playerTwoHealth += healingAmount;
        playerTwoHealth = Mathf.Clamp(playerTwoHealth, 0, 100);
        UpdateHealthBar(playerTwoHealthBar, playerTwoHealth);
    }

    // Update the health bar UI
    private void UpdateHealthBar(Image healthBar, float healthAmount)
    {
        healthBar.fillAmount = healthAmount / 100f;
    }
}
