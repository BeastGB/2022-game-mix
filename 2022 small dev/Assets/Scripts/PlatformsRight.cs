using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlatformsRight : MonoBehaviour
{
    [Header("This is our reference to the Hand. We are using Target Device to track the controller and then later make a function when it's pressed!")]
    private InputDevice targetDevice;
    public Transform hand;
    public InputDeviceCharacteristics Controller;
    [Header("This is our reference to the rigidbody")]
    public Rigidbody rb;
    public GameObject rPlatform;
    public GameObject rHand;
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
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1f)
        {
            rPlatform.SetActive(true);
            rPlatform.transform.position = rHand.transform.position - Offset;
        }
        rPlatform.SetActive(false);
    }   
}