using UnityEngine;
using Terresquall; // Make sure to include the namespace for VirtualJoystick

public class movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private VirtualJoystick joystick; // Reference to your VirtualJoystick component

    private void Update()
    {
        // Get input from the VirtualJoystick
        float horizontal = joystick.GetAxis("horizontal");
        float vertical = joystick.GetAxis("vertical");

        // Create movement vector
        Vector3 direction = new Vector3(horizontal,vertical,0f);

        // Move the character
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}

