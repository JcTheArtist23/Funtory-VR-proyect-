using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool canGetCoin;
    private bool canGetMarbble;

    [Header("VICTORY")]
    public static int _numTotalBolos;       //Número de bolos tirados
    public int numTotalBolos;               //Número de bolos tirados
    private bool levelEnd;                  //El nivel se ha completado?
    private bool allLevelsEnd;              //Todos los niveles se han completado?

    public int numBolosToWin1;              //Número de bolos totales para tirar y obtener la victoria en el nivel 1
    public int numBolosToWin2;              //Número de bolos totales para tirar y obtener la victoria en el nivel 2
    public int numBolosToWin3;              //Número de bolos totales para tirar y obtener la victoria en el nivel 3
    public int numBolosToWin4;              //Número de bolos totales para tirar y obtener la victoria en el nivel 4
    public int numBolosToWin5;              //Número de bolos totales para tirar y obtener la victoria en el nivel 5
    private int numBolosToWin;              //Número de bolos totales para tirar y obtener la victoria en el nivel actual
    
    [Header("BOWLING GAMEOBJECTS")]
    public GameObject level1;               //Nivel de bolos 1
    public GameObject level2;               //Nivel de bolos 2
    public GameObject level3;               //Nivel de bolos 3
    public GameObject level4;               //Nivel de bolos 4
    public GameObject level5;               //Nivel de bolos 5

    [Header("BOWLING LEVELS")]
    public int actualLevel;                 //Nivel en el que el jugador se encuentra jugando
    public int maxLevel;                    //Nivel máximo de bolos

    [Header("UI")]
    public GameObject victoryUI;            //UI que aparece al ganar todos los niveles

    [Header("REWARDS")]
    public GameObject statue;
    public GameObject coin;
    
    [Space(15)]
    public GameObject secondMarbble;
    public GameObject marbbleParent;
    public Transform marbblePositionGeneration;

    private void Awake()
    {
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);

        victoryUI.SetActive(false);
    }

    private void Start()
    {        
        actualLevel = 1;
        allLevelsEnd = false;

        canGetCoin = true;
        canGetMarbble = true;
    }

    private void Update()
    {
        numTotalBolos = _numTotalBolos;

        if(actualLevel == 1)
        {
            level1.SetActive(true);           
            numBolosToWin = numBolosToWin1;
        }
        if(actualLevel == 2)
        {
            level2.SetActive(true);
            numBolosToWin = numBolosToWin2;
        }
        if(actualLevel == 3)
        {
            level3.SetActive(true);
            numBolosToWin = numBolosToWin3;
        }
        if(actualLevel == 4)
        {
            level4.SetActive(true);
            numBolosToWin = numBolosToWin4;
        }
        if(actualLevel == 5)
        {
            level5.SetActive(true);
            numBolosToWin = numBolosToWin5;
        }

        if(numTotalBolos >= numBolosToWin)
        {
            LevelEnd();
        }
        
        if(Input.GetKey(KeyCode.F))
        {
            Victory();
        }
    }

    private void LevelEnd()
    {
        if(actualLevel < maxLevel)
        {
            _numTotalBolos = 0;
            actualLevel++;
        }
        else if(actualLevel >= maxLevel)
        {
            Victory();
        }
    }

    private void Victory()
    {
        victoryUI.SetActive(true);
        allLevelsEnd = true;

        GiveCoin();
        GiveSecondMarbble();
        ReturnToLobby();
    }

    private void GiveCoin()
    {
        if(canGetCoin == true)
        {
            GlobalVariables.coins++;
            GlobalVariables.canSaveCoin = true;
            canGetCoin = false;
        }
    }

    private void GiveSecondMarbble()
    {
        if(canGetMarbble == true)
        {
            GlobalVariables.secondMarble = 1;
            GlobalVariables.canSaveSecondMarble = true;

            GameObject marbble2 = Instantiate(secondMarbble, marbblePositionGeneration.position, marbblePositionGeneration.transform.rotation);
            marbble2.transform.parent = marbbleParent.transform;

            canGetMarbble = false;
        }
    }

    private void ReturnToLobby()
    {
        if(GlobalVariables.canSaveCoin == false && GlobalVariables.canSaveSecondMarble == false)
        {
            victoryUI.SetActive(false);
            //SceneManager.LoadScene("LobbyScene");
        }
    }
}
