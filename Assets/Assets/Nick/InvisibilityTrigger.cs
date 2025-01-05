using UnityEngine;
using UnityEngine.SceneManagement;

public class InvisibilityTrigger : MonoBehaviour
{
    public string sceneToLoad = "NextScene"; // Name of the scene to load
    private Collider triggerCollider;
    private Renderer objectRenderer;
    private bool playerInTrigger = false;

    void Start()
    {
        // Get the Renderer component and disable it
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            objectRenderer.enabled = false;
        }

        // Make the object invisible for 30 seconds
        Invoke(nameof(EnableVisibilityAndTrigger), 30f);
    }

    void EnableVisibilityAndTrigger()
    {
        // Enable the object's Renderer
        if (objectRenderer != null)
        {
            objectRenderer.enabled = true;
        }

        // Add a trigger collider
        triggerCollider = gameObject.AddComponent<BoxCollider>();
        triggerCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerInTrigger)
        {
            playerInTrigger = true;
            Invoke(nameof(LoadNextScene), 2f);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
