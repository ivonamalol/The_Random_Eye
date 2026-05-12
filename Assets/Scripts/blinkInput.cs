using UnityEngine;

public class BlinkInput : MonoBehaviour
{
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
                    Debug.Log("double blink");
                    isWaitingForSecondTap = false;
                    tapCount++;
                }
                else
                {
                    // Too late for double tap, treat previous as single and start new
                    Debug.Log("blink");
                    lastTapTime = currentTime;
                    // Wait again for possible double tap
                }
            }
            else
            {
                // First tap
                lastTapTime = currentTime;
                isWaitingForSecondTap = true;
                // Start waiting for second tap
            }
        }

        // Check if waiting for a second tap has timed out
        if (isWaitingForSecondTap)
        {
            if (Time.time - lastTapTime > doubleTapThreshold)
            {
                // Timeout, it's a single blink
                Debug.Log("blink");
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
                Debug.Log("Too many blinks! (spamming)");
            }
            spamTimer = 0f;
            tapCount = 0;
        }
    }
}
