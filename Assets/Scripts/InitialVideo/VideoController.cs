using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public float videoDuration;

    private VideoPlayer video;

    private void Awake()
    {
        video = GetComponent<VideoPlayer>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        video.Play();
        
        StartCoroutine("LoadLobbyScene");
    }

    private IEnumerator LoadLobbyScene()
    {
        yield return new WaitForSeconds(videoDuration);
        SceneManager.LoadScene("LobbySceneFirstPerson");
    }
}
