using System.Collections;
using UnityEngine;

public class DisappearOnLook : MonoBehaviour
{
    public float lookDuration = 2.0f; // ע��ʱ��
    private Camera playerCamera; // ������
    private bool isLooking = false; // ����Ƿ�����ע��
    private float lookTimer = 0.0f; // ��ʱ��
    private Coroutine lookCoroutine;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        RaycastHit hit;
        // ����������������
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            // ������߻�������
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log("Raycast hit the target object");
                if (!isLooking)
                {
                    isLooking = true;
                    lookCoroutine = StartCoroutine(StartLookTimer());
                }
            }
            else
            {
                if (isLooking)
                {
                    ResetLook();
                }
            }
        }
        else
        {
            if (isLooking)
            {
                ResetLook();
            }
        }
    }

    IEnumerator StartLookTimer()
    {
        lookTimer = 0.0f;
        Debug.Log("Started looking at the object");
        while (lookTimer < lookDuration)
        {
            lookTimer += Time.deltaTime;
            Debug.Log("Looking at object for " + lookTimer + " seconds.");
            yield return null;
        }

        if (lookTimer >= lookDuration)
        {
            Debug.Log("Look duration met, hiding object.");
            gameObject.SetActive(false); // ��������
        }
    }

    void ResetLook()
    {
        isLooking = false;
        lookTimer = 0.0f;
        Debug.Log("Stopped looking at the object");
        if (lookCoroutine != null)
        {
            StopCoroutine(lookCoroutine);
            lookCoroutine = null;
        }
    }
}
