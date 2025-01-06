using UnityEngine;
using UnityEngine.SceneManagement;

public class InvisibilityTrigger : MonoBehaviour
{
    [SerializeField] private string targetSceneName = "lobby";
    private Collider triggerCollider;
    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer and Collider components and disable them
        objectRenderer = GetComponent<Renderer>();
        triggerCollider = GetComponent<Collider>();

        if (objectRenderer != null)
        {
            objectRenderer.enabled = false;
        }

        if (triggerCollider != null)
        {
            triggerCollider.enabled = false;
        }

        // Reactivate the object and trigger after 30 seconds
        Invoke(nameof(EnableVisibilityAndTrigger), 30f);
    }

    void EnableVisibilityAndTrigger()
    {
        // Enable the object's Renderer and Collider
        if (objectRenderer != null)
        {
            objectRenderer.enabled = true;
        }

        if (triggerCollider != null)
        {
            triggerCollider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the specified target scene
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
