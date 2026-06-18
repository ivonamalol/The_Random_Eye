using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkInput : MonoBehaviour
{
    public static int blinkValue = 0; // 1 for single blink, 0 for double blink
    private float lastTapTime = 0f;
    private const float doubleTapThreshold = 0.3f; // Max time between taps for double tap
    private bool isWaitingForSecondTap = false;

    // For spam detection
    private float spamTimer = 0f;
    private const float spamThreshold = 2f; // Time window to count spamming
    private int tapCount = 0;

    void Update()
    {
        // Detect touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float currentTime = Time.time;

            if (isWaitingForSecondTap)
            {
                // Check if this tap is within double tap threshold
                if (currentTime - lastTapTime <= doubleTapThreshold)
                {
                    // Double blink detected: interpret as 0
                    HandleBlink(0);
                    isWaitingForSecondTap = false;
                    tapCount++;
                }
                else
                {
                    // Too late for double tap, treat previous as single and start new
                    HandleBlink(1); // Previous tap was a single blink
                    lastTapTime = currentTime;
                    isWaitingForSecondTap = true;
                }
            }
            else
            {
                // First tap
                lastTapTime = currentTime;
                isWaitingForSecondTap = true;
            }
        }

        // Check if waiting for a second tap has timed out
        if (isWaitingForSecondTap)
        {
            if (Time.time - lastTapTime > doubleTapThreshold)
            {
                // Timeout, it's a single blink
                HandleBlink(1);
                isWaitingForSecondTap = false;
                tapCount++;
            }
        }

        // Spam detection
        spamTimer += Time.deltaTime;
        if (spamTimer >= spamThreshold)
        {
            if (tapCount > 5) // arbitrary limit for spam
            {
                HandleSpam(); // Custom action for spamming
            }
            spamTimer = 0f;
            tapCount = 0;
        }
    }

    private static void HandleBlink(int value)
    {
        // value: 1 for single blink, 0 for double blink
        Debug.Log($"Blink interpreted as: {value}");

        if (value == 1)
        {
            // Handle single blink logic here
            Debug.Log("Single blink detected!");
            blinkValue = 1; // Set blinkValue to 1 for single blink
        }
        else if (value == 0)
        {
            // Handle double blink logic here
            Debug.Log("Double blink detected!");
            blinkValue = 0; // Set blinkValue to 0 for double blink

        }
        // TODO: Add your logic here for handling 1 or 0

    }

    private void HandleSpam()
    {
        Debug.Log("Custom spam action triggered!");
        // TODO: Add your custom spam action here
    }
    


}
