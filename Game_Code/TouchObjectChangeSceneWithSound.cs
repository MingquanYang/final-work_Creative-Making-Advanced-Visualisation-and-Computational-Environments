using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchObjectChangeSceneWithSound : MonoBehaviour
{
    public AudioSource touchSound; 
    public string sceneToLoad = "YourSceneName"; 
    public Image blackScreen; // black UI Image

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeSceneRoutine());
        }
    }

    IEnumerator ChangeSceneRoutine()
    {
        // sound play
        touchSound.Play();

        // fade to black
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / 3.0f)
        {
            Color newColor = new Color(0, 0, 0, t);
            blackScreen.color = newColor;
            yield return null;
        }

        // wait for seconds
        yield return new WaitForSeconds(3);

        // load new scene
        SceneManager.LoadScene(sceneToLoad);
    }
}