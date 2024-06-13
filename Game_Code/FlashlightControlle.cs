using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlashlightController : MonoBehaviour
{
    public Image flashlightMask;
    public RectTransform targetArea; // Target area
    private RectTransform maskRectTransform;

    void Start()
    {
        if (flashlightMask != null)
        {
            maskRectTransform = flashlightMask.GetComponent<RectTransform>();
        }
        Cursor.visible = false; // Hide cursor
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)transform,
                Input.mousePosition, null,
                out movePos);

            if (maskRectTransform != null)
            {
                maskRectTransform.localPosition = movePos;
            }

            if (targetArea != null && RectTransformUtility.RectangleContainsScreenPoint(targetArea, Input.mousePosition, null))
            {
                SceneManager.LoadScene("Scene6"); 
            }
        }
    }

    public void ActivateFlashlight()
    {
        gameObject.SetActive(true);
    }
}
