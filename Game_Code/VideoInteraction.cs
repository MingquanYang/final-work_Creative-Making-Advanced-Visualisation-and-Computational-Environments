using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // ���볡�����������ռ�

public class VideoInteraction : MonoBehaviour
{
    public GameObject textUI; // ��ʾ�ı�UI
    public GameObject videoUI; // ��ƵUI
    private Camera playerCamera; // ������
    private bool isViewingVideo = false; // ����Ƿ����ڲ鿴��Ƶ
    private VideoPlayer videoPlayer; // VideoPlayer���
    public string nextSceneName; // Ҫ��ת�ĳ�������

    void Start()
    {
        playerCamera = Camera.main;
        textUI.SetActive(false); // ��ʼ״̬����ʾ�ı�
        videoUI.SetActive(false); // ��ʼ״̬����ʾ��Ƶ
        videoPlayer = videoUI.GetComponent<VideoPlayer>(); // ��ȡVideoPlayer���

        // ��Ӳ�������¼�����
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        PlayerInteraction();
    }

    void PlayerInteraction()
    {
        RaycastHit hit;
        // ����������������
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            // ������߻�������
            if (hit.collider.gameObject == gameObject)
            {
                // ������û�в鿴��Ƶ����ʾ��ʾ�ı�
                if (!isViewingVideo)
                {
                    textUI.SetActive(true);
                }

                // ����Ұ���E��
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isViewingVideo = !isViewingVideo;
                    videoUI.SetActive(isViewingVideo);

                    if (isViewingVideo)
                    {
                        textUI.SetActive(false); // �鿴��Ƶʱ�����ı�
                        videoPlayer.Play(); // ������Ƶ
                    }
                    else
                    {
                        videoPlayer.Stop(); // ֹͣ��Ƶ����
                    }
                }
            }
            else if (!isViewingVideo) // �������δ�������������δ�鿴��Ƶ
            {
                textUI.SetActive(false);
            }
        }
        else if (!isViewingVideo) // �������δ�������������δ�鿴��Ƶ
        {
            textUI.SetActive(false);
        }
    }

    // ��Ƶ�������ʱ����
    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video finished, switching to next scene.");
        SceneManager.LoadScene("Scene3"); // ��ת����һ������
    }
}
