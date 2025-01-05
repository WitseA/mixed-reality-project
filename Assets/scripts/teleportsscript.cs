using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class PortalTransport : MonoBehaviour
{
    [SerializeField] private string targetSceneName = "test_portals"; // Replace with your target scene name

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the player tag
        if (other.CompareTag("Player"))
        {
            // Check if this GameObject is tagged as portal1
            if (gameObject.CompareTag("Player"))
            {
                // Load the specified target scene
                SceneManager.LoadScene(targetSceneName);
            }
        }
    }
}
