using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable))]
public class SceneTransporter : MonoBehaviour
{
    [Tooltip("The name of the scene to load on interaction.")]
    [SerializeField] private string targetSceneName;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    private void OnEnable()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnInteract);
            Debug.Log($"Listener added for {name}'s selectEntered event.");
        }
        else
        {
            Debug.LogError("No XRBaseInteractable component found. Please attach one to this GameObject.");
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnInteract);
        }
    }

    private void OnInteract(SelectEnterEventArgs args)
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            Debug.Log($"Loading scene: {targetSceneName}");
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("Target scene name is not set! Cannot load scene.");
        }
    }
}