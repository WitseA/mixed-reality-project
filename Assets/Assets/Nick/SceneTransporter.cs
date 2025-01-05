using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SceneTransporter : MonoBehaviour
{
    [Tooltip("The name of the scene to load on interaction.")]
    [SerializeField] private string targetSceneName;

    private void OnEnable()
    {
        // Subscribe to the interaction event
        var interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnInteract);
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from the interaction event
        var interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnInteract);
        }
    }

    private void OnInteract(SelectEnterEventArgs args)
    {
        // Ensure the scene name is valid
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("Target scene name is not set!");
        }
    }
}
