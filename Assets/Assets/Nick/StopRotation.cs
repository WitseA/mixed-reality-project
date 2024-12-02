using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotation : MonoBehaviour
{
    void LateUpdate()
    {
        // Lock rotation to identity while keeping position
        transform.rotation = Quaternion.identity;
    }
}
