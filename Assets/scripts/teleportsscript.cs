using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class PortalTransport : MonoBehaviour
{
    [SerializeField] private string targetSceneName = "lobby"; // Replace with your target scene name

    private void OnTriggerEnter(Collider other)
    {
        // Load the specified target scene
        SceneManager.LoadScene(targetSceneName);
    }
}
