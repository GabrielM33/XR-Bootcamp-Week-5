using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CubeScaler : MonoBehaviour
{
    public XRNode leftHand;
    public XRNode rightHand;
    public GameObject cubePrefab;
    private GameObject currentCube;
    private Vector3 initialHandDistance;
    private Vector3 initialScale;

    void Update()
    {
        // Get the current positions of the hands
        Vector3 leftHandPosition, rightHandPosition;
        InputDevices.GetDeviceAtXRNode(leftHand).TryGetFeatureValue(CommonUsages.devicePosition, out leftHandPosition);
        InputDevices.GetDeviceAtXRNode(rightHand).TryGetFeatureValue(CommonUsages.devicePosition, out rightHandPosition);

        // Check if the button is pressed
        bool isButtonPressed;
        InputDevices.GetDeviceAtXRNode(leftHand).TryGetFeatureValue(CommonUsages.primaryButton, out isButtonPressed);

        if (isButtonPressed)
        {
            if (currentCube == null)
            {
                // Instantiate a new cube
                currentCube = Instantiate(cubePrefab, (leftHandPosition + rightHandPosition) / 2, Quaternion.identity);
                initialHandDistance = rightHandPosition - leftHandPosition;
                initialScale = currentCube.transform.localScale;
            }
            else
            {
                // Scale the cube based on the distance between the hands
                Vector3 currentHandDistance = rightHandPosition - leftHandPosition;
                currentCube.transform.localScale = initialScale * (currentHandDistance.magnitude / initialHandDistance.magnitude);
            }
        }
        else
        {
            // Reset the current cube when the button is released
            currentCube = null;
        }
    }
}