using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{   
    public string sceneName;
    
    private void OnTriggerEnter(Collider teleport)
    {
        if(teleport.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SceneName", LoadSceneMode.Additive);
        }
    }
}
