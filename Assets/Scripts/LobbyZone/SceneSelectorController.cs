using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelectorController : MonoBehaviour
{
    [Header("SET ACTIVE TIMES")]
    public float setActiveTimeBackground;       //Tiempo para que aparezca el fondo de la UI
    public float setActiveTimeImages;           //Tiempo para que aparezca cada una de las imagenes de los minijuegos
    public float setActiveTimeTitle;            //Tiempo para que aparezca el título de la UI

    [Header("SCENE SELECTION")]
    public int sceneSelected;                   //Cual es el minijuego seleccionad0 (1 = Bowling    /   2 = Golf    /   3 = Other)
    public float sceneSelectedTime;             //Tiempo hasta que se pueden seleccionar los minijuegos
    public bool canSelectScene;                 //Se pueden seleccionar los minijuegos?
    
    [Header("UI GAMEOBJECTS")]
    public GameObject sceneSelector;            //Fondo de la UI
    public GameObject bowling;                  //Imagen del minijuego "Bowling"
    public GameObject golf;                     //Imagen del minijuego "Golf"
    public GameObject other;                    //Imagen del minijuego "Other"
    public GameObject titleSceneSelector;       //Titulo de la selección de minijuegos

    [Header("UI GAMEOBJECTS 2")]
    public GameObject bowlingSelected;          //Efecto de cuando el minijuego "Bowling" bolos está seleccionada
    public GameObject golfSelected;             //Efecto de cuando el minijuego "Golf" está seleccionada
    public GameObject otherSelected;            //Efecto de cuando el minijuego "Other" está seleccionada

    private void Awake()
    {
        sceneSelector.SetActive(false);
        bowling.SetActive(false);
        golf.SetActive(false);
        other.SetActive(false);
        titleSceneSelector.SetActive(false);
    }

    private void Start()
    {
        canSelectScene = false;
        sceneSelected = 1;

        StartCoroutine("SetActiveUI_SceneSelector");
    }

    //Aparce el fondo de la UI 
    private IEnumerator SetActiveUI_SceneSelector()
    {
        yield return new WaitForSeconds(setActiveTimeBackground);
        sceneSelector.SetActive(true);
        StartCoroutine("SetActiveUI_Bowling");
    }

    //Aparce la imagen del minijuego "Bowling"
    private IEnumerator SetActiveUI_Bowling()
    {
        yield return new WaitForSeconds(setActiveTimeImages);
        bowling.SetActive(true);
        StartCoroutine("SetActiveUI_Golf");
    }

    //Aparce la imagen del minijuego "Golf"
    private IEnumerator SetActiveUI_Golf()
    {
        yield return new WaitForSeconds(setActiveTimeImages);
        golf.SetActive(true);
        StartCoroutine("SetActiveUI_Other");
    }

    //Aparce la imagen del minijuego "Other"
    private IEnumerator SetActiveUI_Other()
    {
        yield return new WaitForSeconds(setActiveTimeImages);
        other.SetActive(true);
        StartCoroutine("SetActiveUI_Title");

    }

    //Aparece el título del seleccionador de la UI
    private IEnumerator SetActiveUI_Title()
    {
        yield return new WaitForSeconds(setActiveTimeTitle);
        titleSceneSelector.SetActive(true);

        StartCoroutine("SelectionScene");
    }

    //Las miniguejos ya se pueden seleccionar
    private IEnumerator SelectionScene()
    {
        yield return new WaitForSeconds(sceneSelectedTime);
        canSelectScene = true;
    }

    private void Update()
    {
        if(sceneSelected > 3)
        {
            sceneSelected = 1;
        }
        else if(sceneSelected < 1)
        {
            sceneSelected = 3;
        }

        if(canSelectScene == true)
        {
            ChangeSelectScene();
            SceneSelectedEffect();
            SceneTeleport();
        }
    }

    private void ChangeSelectScene()
    {
        
    }

    //Efecto para que se vea cual de los minijuegos está seleccionado
    private void SceneSelectedEffect()
    {
        if(canSelectScene == true)
        {
            if(sceneSelected == 1)
            {
                bowlingSelected.SetActive(true);
                golfSelected.SetActive(false);
                otherSelected.SetActive(false);
            }
            else if(sceneSelected == 2)
            {
                bowlingSelected.SetActive(false);
                golfSelected.SetActive(true);
                otherSelected.SetActive(false);
            }
            else if(sceneSelected == 3)
            {
                bowlingSelected.SetActive(false);
                golfSelected.SetActive(false);
                otherSelected.SetActive(true);
            }
        }           
    }

    private void SceneTeleport()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(sceneSelected == 1)
            {
                SceneManager.LoadScene("BowlingScene");
            }
            else if(sceneSelected ==2)
            {
                
            }
            else if(sceneSelected == 3)
            {
                
            }
        }
    }
}
