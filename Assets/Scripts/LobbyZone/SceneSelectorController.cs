using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneSelectorController : MonoBehaviour
{
    public float setActiveTime1;                //Tiempo para que aparezca el fondo de la UI
    public float setActiveTime2;                //Tiempò para que aparezca cada una de las imagenes de los minijuegos

    [Header("SCENE SELECTION")]
    public int sceneSelected;                   //Cual es el minijuego seleccionad0 (1 = Bowling    /   2 = Golf    /   3 = Other)
    public float sceneSelectedTime;             //Tiempo hasta que se pueden seleccionar los minijuegos
    public bool canSelectScene;
    
    [Header("UI GAMEOBJECTS")]
    public GameObject sceneSelector;            //Fondo de la UI
    public GameObject bowling;                  //Imagen del minijuego "Bowling"
    public GameObject golf;                     //Imagen del minijuego "Golf"
    public GameObject other;                    //Imagen del minijuego "Other"

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
    }

    private void Start()
    {
        canSelectScene = false;
        StartCoroutine("SetActiveUI_SceneSelector");
    }

    //Aparce el fondo de la UI 
    private IEnumerator SetActiveUI_SceneSelector()
    {
        yield return new WaitForSeconds(setActiveTime1);
        sceneSelector.SetActive(true);
        StartCoroutine("SetActiveUI_Bowling");
    }

    //Aparce la imagen del minijuego "Bowling"
    private IEnumerator SetActiveUI_Bowling()
    {
        yield return new WaitForSeconds(setActiveTime2);
        bowling.SetActive(true);
        StartCoroutine("SetActiveUI_Golf");
    }

    //Aparce la imagen del minijuego "Golf"
    private IEnumerator SetActiveUI_Golf()
    {
        yield return new WaitForSeconds(setActiveTime2);
        golf.SetActive(true);
        StartCoroutine("SetActiveUI_Other");
    }

    //Aparce la imagen del minijuego "Other"
    private IEnumerator SetActiveUI_Other()
    {
        yield return new WaitForSeconds(setActiveTime2);
        other.SetActive(true);

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

        sceneSelectedEffect();
    }

    //Efecto para que se vea cual de los minijuegos está seleccionado
    private void sceneSelectedEffect()
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
}
