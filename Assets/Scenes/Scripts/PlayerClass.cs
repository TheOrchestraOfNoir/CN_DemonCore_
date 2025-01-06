using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health = 100; // Player health, starts at 100
    public string PlayerName;

    public void ResetHealth()
    {
        // Resets health to full
        Health = 100;
    }
}
