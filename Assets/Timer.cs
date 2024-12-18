using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float countdownTime = 10f; // Set the starting countdown time in seconds

    float currentTime;

    void Start()
    {
        currentTime = countdownTime; // Initialize the timer
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Decrease the time using deltaTime
            currentTime = Mathf.Max(currentTime, 0); // Clamp to zero to prevent negative time
            timerText.text = currentTime.ToString("F2"); // Show time with 2 decimal places
        }
        else
        {
            // Optional: Add logic when the countdown finishes
            timerText.text = "0.00";
        }
    }
}

