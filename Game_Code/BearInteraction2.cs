using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BearInteraction2 : MonoBehaviour
{
    public Transform player;
    public Camera playerCamera; 
    public TextMeshProUGUI interactTMPText; // interaction text
    public float interactionDistance = 1f; // diistance with player and bear

    private void Start()
    {
        interactTMPText.gameObject.SetActive(false); // not display interaction text when game start
    }

    void Update()
    {
        RaycastHit hit;
        // a ray from player's camera
        bool isHit = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance);

        // if the ray on the bear
        if (isHit && hit.collider.gameObject == gameObject)
        {
            interactTMPText.gameObject.SetActive(true); // show the interaction text

            // if player enter the botton
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithBear(); // start the interaction
            }
        }
        else
        {
            interactTMPText.gameObject.SetActive(false); // if ray haven't on the bear,don't show the interaction text
        }
    }

    void InteractWithBear()
    {
        Debug.Log("Interacted with the bear!");
        interactTMPText.gameObject.SetActive(false); // no interaction text after interacted
        LoadNextScene(); // load next scene
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Scene3"); //next scene
    }
}
