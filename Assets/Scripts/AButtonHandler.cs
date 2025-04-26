using UnityEngine;
using UnityEngine.InputSystem;

public class AButtonHandler : MonoBehaviour
{
    public InputActionReference aButtonAction; // Assign this in Inspector

    private void OnEnable()
    {
        aButtonAction.action.Enable();
        aButtonAction.action.performed += OnAButtonPressed;
    }

    private void OnDisable()
    {
        aButtonAction.action.performed -= OnAButtonPressed;
    }

    private void OnAButtonPressed(InputAction.CallbackContext ctx)
    {
        Debug.Log("A Button Pressed!");
        // Your custom logic here
    }
}