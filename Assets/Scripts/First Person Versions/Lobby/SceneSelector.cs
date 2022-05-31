using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public int sceneSelected;
    public static bool canUseUI;

    public GameObject bowlingSelected;
    public GameObject golfSelected;
    public GameObject otherSelected;

    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        sceneSelected = 1;
        canUseUI = false;
    }

    private void Update()
    {
        if(canUseUI == true)
        {
            SceneSelectedControl();
            SceneSelectedUI();
            SceneSelectedEnter();
        }
    }

    private void SceneSelectedControl()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            sceneSelected++;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sceneSelected--;
        }

        if(sceneSelected > 3)
        {
            sceneSelected = 1;
        }
        if(sceneSelected < 1)
        {
            sceneSelected = 3;
        }
    }

    private void SceneSelectedUI()
    {
        if(sceneSelected == 1)
        {
            bowlingSelected.SetActive(true);
            golfSelected.SetActive(false);
            otherSelected.SetActive(false);
        }
        if(sceneSelected == 2)
        {
            bowlingSelected.SetActive(false);
            golfSelected.SetActive(true);
            otherSelected.SetActive(false);
        }
        if(sceneSelected == 3)
        {
            bowlingSelected.SetActive(false);
            golfSelected.SetActive(false);
            otherSelected.SetActive(true);
        }
    }

    private void SceneSelectedEnter()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            if(sceneSelected == 1)
            {
                SceneManager.LoadScene("BowlingSceneFirstPerson");
            }
            else if(sceneSelected == 2)
            {
                audio.Play();
            }
            else if(sceneSelected == 3)
            {
                audio.Play();
            }
        }
    }
}
