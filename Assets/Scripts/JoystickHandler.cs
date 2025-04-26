using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickHandler : MonoBehaviour
{
    public InputActionReference joystickAction; // Assign this in Inspector
    public float threshold = 0.5f; // Minimum joystick tilt to trigger

    private void OnEnable()
    {
        joystickAction.action.Enable();
        joystickAction.action.performed += OnJoystickMoved;
    }

    private void OnDisable()
    {
        joystickAction.action.performed -= OnJoystickMoved;
    }

    private void OnJoystickMoved(InputAction.CallbackContext context)
    {
        Vector2 joystickValue = context.ReadValue<Vector2>();

        // Check if joystick is pushed forward (Y-axis)
        if (joystickValue.y > threshold)
        {
            Debug.Log("Joystick Forward!");
            // Add your custom logic here
        }
    }
}