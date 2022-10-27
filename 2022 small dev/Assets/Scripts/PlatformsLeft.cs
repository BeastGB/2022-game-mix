using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlatformsLeft : MonoBehaviour
{
    [Header("This is our reference to the Hand. We are using Target Device to track the controller and then later make a function when it's pressed!")]
    private InputDevice targetDevice;
    public Transform hand;
    public InputDeviceCharacteristics Controller;
    [Header("This is our reference to the rigidbody")]
    public Rigidbody rb;
    public GameObject lHand;
    public GameObject lPlatform;
    public Vector3 Offset;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(Controller, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    void Update()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            lPlatform.SetActive(true);
            lPlatform.transform.position = lHand.transform.position - Offset;
        }
    }
}