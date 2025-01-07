using UnityEngine;

public class MoveObjectOnCollision : MonoBehaviour
{
    public float moveDownDistance = 5f; // Distance to move down
    public float moveDuration = 2f;     // Duration of the movement

    private Vector3 targetPosition;    // Target position for movement
    private Vector3 originalPosition;  // Original position of the object
    private bool isMoving = false;     // To track if the object is already moving

    void Start()
    {
        // Store the original position of the object
        originalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Calculate the target position
        targetPosition = originalPosition - new Vector3(0, moveDownDistance, 0);

        // Start the movement coroutine
        StartCoroutine(MoveObject());
    }

    private System.Collections.IEnumerator MoveObject()
    {
        isMoving = true; // Prevent multiple triggers
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration;

            // Ease in and out using a smooth step function
            t = Mathf.SmoothStep(0f, 1f, t);

            // Interpolate between the original and target position
            transform.position = Vector3.Lerp(originalPosition, targetPosition, t);

            yield return null;
        }

        // Ensure the final position is exactly the target position
        transform.position = targetPosition;
        isMoving = false;
    }
}