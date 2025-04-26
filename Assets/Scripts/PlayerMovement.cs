using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class ControllerInputDetector : MonoBehaviour
{
    public XRNode controllerNode = XRNode.RightHand;
    public bool useSimulator = false; // Toggle in Inspector

    private InputDevice targetDevice;
    private bool deviceFound;

    void Start()
    {
        if (useSimulator)
            Debug.Log("Using XR Device Simulator");

        FindController();
    }

    void FindController()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(controllerNode, devices);

        foreach (var device in devices)
        {
            // Special handling for simulator
            if (useSimulator && device.name.Contains("Simulator"))
            {
                targetDevice = device;
                deviceFound = true;
                Debug.Log("Using simulator controller");
                return;
            }

            // Physical controller check
            if (!useSimulator && device.characteristics.HasFlag(InputDeviceCharacteristics.Controller))
            {
                targetDevice = device;
                deviceFound = true;
                Debug.Log("Using physical controller: " + device.name);
                return;
            }
        }

        Debug.LogError(useSimulator ?
            "Simulator not found! Enable in XR Plug-in Management" :
            "Physical controller not found!");
    }

    void Update()
    {
        if (!deviceFound) return;

        if (useSimulator)
        {
            // Simulator-specific input (Space = A button)
            if (Input.GetKeyDown(KeyCode.Space))
                Debug.Log("Simulator A Pressed");
        }
        else
        {
            // Physical controller input
            if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed) && pressed)
                Debug.Log("Physical A Pressed");
        }
    }
}