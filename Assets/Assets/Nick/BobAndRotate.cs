using UnityEngine;

public class BobAndRotate : MonoBehaviour
{
    // Variables to set in the Inspector
    public float yStart = 0f; // Starting Y position
    public float yEnd = 5f; // Ending Y position
    public float rotationAmount = 360f; // Total rotation amount
    public float startTimeOffset = 0f; // Start time offset in seconds (0-60)

    private float loopDuration = 60f; // Duration of the loop (60 seconds)
    private float elapsedTime; // Elapsed time for looping

    void Start()
    {
        elapsedTime = startTimeOffset % loopDuration; // Apply start time offset
    }

    void Update()
    {
        // Update the elapsed time, looping back after 60 seconds
        elapsedTime += Time.deltaTime;
        if (elapsedTime > loopDuration)
            elapsedTime -= loopDuration;

        // Calculate progress (0 to 1) within the loop
        float progress = elapsedTime / loopDuration;

        // Determine position for bobbing
        float bobProgress = Mathf.PingPong(progress * 4f, 1f); // Bob up and down twice in 60 seconds
        float yPosition = Mathf.Lerp(yStart, yEnd, bobProgress); // Linear interpolation between yStart and yEnd

        // Apply rotation and position
        float rotation = rotationAmount * progress; // Rotate linearly over time
        transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
}
