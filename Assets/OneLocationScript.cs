using UnityEngine;

public class OneLocationScript : MonoBehaviour
{
    public float rotationLimit = 200f; // Limit of rotation in degrees (200 degrees)
    private Vector3 initialPosition;  // Player's initial position
    private float initialYRotation;  // Player's initial Y rotation
    private float currentYRotation; // Current Y rotation

    void Start()
    {
        // Record the initial position and rotation of the player
        initialPosition = transform.position;
        initialYRotation = transform.eulerAngles.y;
        currentYRotation = initialYRotation;
    }

    void Update()
    {
        // Keep the player in the same position
        transform.position = initialPosition;

        // Check for user input to rotate (for testing purpose i made so that the player rotates with arrow keys)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
          
            currentYRotation -= 1f; // Adjust the rotation speed 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
           
            currentYRotation += 1f; // Adjust the rotation speed 
        }

        // Clamp the rotation to be within the limits
        float clampedYRotation = Mathf.Clamp(
            currentYRotation,
            initialYRotation - rotationLimit / 2f,
            initialYRotation + rotationLimit / 2f
        );

        // Apply the clamped rotation to the player
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,  // Keep the original X rotation
            clampedYRotation,        // Apply the clamped Y rotation
            transform.eulerAngles.z   // Keep the original Z rotation
        );

        // Debug log to show the player's current rotation in the Y-axis
        // Debug.Log("Current Y Rotation: " + transform.eulerAngles.y);
    }
}
