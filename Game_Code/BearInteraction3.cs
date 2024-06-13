using UnityEngine;
using TMPro;

public class BearInteraction3 : MonoBehaviour
{
    public Camera playerCamera;
    public TextMeshProUGUI interactTMPText; // Interaction text
    public float interactionDistance = 2f; // Distance between player and interactable object
    public GameObject flashlightCanvas; // The canvas containing the flashlight effect
    public FlashlightController flashlightController; // Reference to the flashlight controller

    private void Start()
    {
        if (interactTMPText != null)
        {
            interactTMPText.gameObject.SetActive(false); // Initially hide the interaction text
        }
        if (flashlightCanvas != null)
        {
            flashlightCanvas.SetActive(false); // Initially hide the flashlight canvas
        }
    }

    void Update()
    {
        RaycastHit hit;
        // Cast a ray from the player's camera
        bool isHit = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance);

        // If the ray hits the interactable object
        if (isHit && hit.collider.gameObject == gameObject && !flashlightCanvas.activeSelf)
        {
            if (interactTMPText != null)
            {
                interactTMPText.gameObject.SetActive(true); // Show the interaction text
            }

            // If the player presses the 'E' key
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithBear(); // Start the interaction
            }
        }
        else
        {
            if (interactTMPText != null && interactTMPText.gameObject.activeSelf)
            {
                interactTMPText.gameObject.SetActive(false); // Hide the interaction text if the ray doesn't hit the interactable object
            }
        }
    }

    void InteractWithBear()
    {
        Debug.Log("Interacted with the bear!");
        if (interactTMPText != null)
        {
            interactTMPText.gameObject.SetActive(false); // Hide the interaction text after interacting
        }
        if (flashlightCanvas != null)
        {
            flashlightCanvas.SetActive(true); // Show the flashlight canvas
        }
        if (flashlightController != null)
        {
            flashlightController.ActivateFlashlight(); // Activate flashlight control
        }
    }
}
