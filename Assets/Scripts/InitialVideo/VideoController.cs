using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    private float videoDuration = 5f;

    private VideoPlayer video;
    private AudioSource audio;

    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        video.Play();
        audio.Play();
        
        StartCoroutine("LoadLobbyScene");
    }

    private IEnumerator LoadLobbyScene()
    {
        yield return new WaitForSeconds(videoDuration);
        SceneManager.LoadScene("LobbyScene");
    }
}
