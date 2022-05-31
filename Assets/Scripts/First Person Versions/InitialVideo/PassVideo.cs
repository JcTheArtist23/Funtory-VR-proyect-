using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassVideo : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            anim.SetBool("Black", true);
            StartCoroutine("PassScene");
        }
    }

    private IEnumerator PassScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("LobbySceneFirstPerson");
    }
}
