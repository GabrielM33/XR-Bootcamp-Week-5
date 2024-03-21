using UnityEngine;

public class ResetButton : MonoBehaviour
{
    // Reference to the game objects that you want to reset
    public GameObject[] gameObjects;

    // Initial positions and rotations of the game objects
    private Vector3[] initialPositions;
    private Quaternion[] initialRotations;

    void Start()
    {
        // Save the initial positions and rotations of the game objects
        initialPositions = new Vector3[gameObjects.Length];
        initialRotations = new Quaternion[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            initialPositions[i] = gameObjects[i].transform.position;
            initialRotations[i] = gameObjects[i].transform.rotation;
        }
    }

    public void ResetGameObjects()
    {
        // Reset the positions and rotations of the game objects
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].transform.position = initialPositions[i];
            gameObjects[i].transform.rotation = initialRotations[i];

            // If the game objects have rigidbodies, also reset their velocities
            Rigidbody rb = gameObjects[i].GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}