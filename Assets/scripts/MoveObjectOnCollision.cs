using UnityEngine;

public class MoveObjectOnCollision : MonoBehaviour
{
    public float moveDownDistance = 5f; // Distance to move down

    private Vector3 _originalPosition;

    void Start()
    {
        // Store the original position of the object
        _originalPosition = transform.position;
    }

    // Called when another object enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Move the object down by the specified distance
        transform.position = new Vector3(
            _originalPosition.x,
            _originalPosition.y - moveDownDistance,
            _originalPosition.z
        );
    }
}