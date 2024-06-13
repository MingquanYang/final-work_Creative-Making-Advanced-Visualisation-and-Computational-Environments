using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // 引入场景管理命名空间

public class VideoInteraction : MonoBehaviour
{
    public GameObject textUI; // 提示文本UI
    public GameObject videoUI; // 视频UI
    private Camera playerCamera; // 玩家相机
    private bool isViewingVideo = false; // 玩家是否正在查看视频
    private VideoPlayer videoPlayer; // VideoPlayer组件
    public string nextSceneName; // 要跳转的场景名称

    void Start()
    {
        playerCamera = Camera.main;
        textUI.SetActive(false); // 初始状态不显示文本
        videoUI.SetActive(false); // 初始状态不显示视频
        videoPlayer = videoUI.GetComponent<VideoPlayer>(); // 获取VideoPlayer组件

        // 添加播放完成事件监听
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void Update()
    {
        PlayerInteraction();
    }

    void PlayerInteraction()
    {
        RaycastHit hit;
        // 从玩家相机发射射线
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            // 如果射线击中物体
            if (hit.collider.gameObject == gameObject)
            {
                // 如果玩家没有查看视频，显示提示文本
                if (!isViewingVideo)
                {
                    textUI.SetActive(true);
                }

                // 当玩家按下E键
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isViewingVideo = !isViewingVideo;
                    videoUI.SetActive(isViewingVideo);

                    if (isViewingVideo)
                    {
                        textUI.SetActive(false); // 查看视频时隐藏文本
                        videoPlayer.Play(); // 播放视频
                    }
                    else
                    {
                        videoPlayer.Stop(); // 停止视频播放
                    }
                }
            }
            else if (!isViewingVideo) // 如果射线未击中物体且玩家未查看视频
            {
                textUI.SetActive(false);
            }
        }
        else if (!isViewingVideo) // 如果射线未击中物体且玩家未查看视频
        {
            textUI.SetActive(false);
        }
    }

    // 视频播放完成时调用
    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video finished, switching to next scene.");
        SceneManager.LoadScene("Scene3"); // 跳转到下一个场景
    }
}
