using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    public GameObject textUI; 
    public GameObject imageUI; 
    private Camera playerCamera; 
    private bool isViewingImage = false; //if player view the image

    void Start()
    {
        playerCamera = Camera.main; 
        textUI.SetActive(false); // not show the text when start
        imageUI.SetActive(false); // not show the image when start
    }

    void Update()
    {
        PlayerInteraction();
    }

    void PlayerInteraction()
    {
        RaycastHit hit;
        // a ray from player's camera
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            // if ray on the item
            if (hit.collider.gameObject == gameObject)
            {
                // if player doesn't view image,show the text
                if (!isViewingImage)
                {
                    textUI.SetActive(true);
                }

                // when player enter the botton
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // change if check the image
                    isViewingImage = !isViewingImage;
                    imageUI.SetActive(isViewingImage);

                    // if start check the image,not show the text
                    if (isViewingImage)
                    {
                        textUI.SetActive(false);
                    }
                }
            }
            else if (!isViewingImage) // if no ray on anything,and player doesn't check the image
            {
                textUI.SetActive(false);
            }
        }
        else if (!isViewingImage) // if no ray on anything,and player doesn't check the image
        {
            textUI.SetActive(false);
        }
    }
}
