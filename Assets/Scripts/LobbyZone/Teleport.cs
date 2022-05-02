using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public GameObject teleportUI;
    public GameObject golfScene;
    public GameObject bowlingScene;
   
    private void OnTriggerStay(Collider teleport)
    {
        if(teleport.gameObject.tag == "Player")
        {
            teleportUI.SetActive(true);
        }
        else
        {
            teleportUI.SetActive(false);
        }
    }

    public void TeleportScene()
    {
        SceneManager.LoadScene("SceneName");
    }
}
