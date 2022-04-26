using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   
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
    public GameObject nextLevelUI;          //UI que aparece al ganar un nivel
    public GameObject victoryUI;            //UI que aparece al ganar todos los niveles

    private void Start()
    {
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        
        actualLevel = 1;
        allLevelsEnd = false;
        victoryUI.SetActive(false);
    }

    private void Update()
    {
        GlobalVariables.canDeleteKeys = false;

        numTotalBolos = _numTotalBolos;

        if(actualLevel == 1)
        {
            level1.SetActive(true);           
            numBolosToWin = numBolosToWin1;
        }
        if(actualLevel == 2)
        {
            level2.SetActive(true);
            level1.SetActive(false);
            numBolosToWin = numBolosToWin2;
        }
        if(actualLevel == 3)
        {
            level3.SetActive(true);
            level2.SetActive(false);
            numBolosToWin = numBolosToWin3;
        }
        if(actualLevel == 4)
        {
            level4.SetActive(true);
            level3.SetActive(false);
            numBolosToWin = numBolosToWin4;
        }
        if(actualLevel == 5)
        {
            level5.SetActive(true);
            level4.SetActive(false);
            numBolosToWin = numBolosToWin5;
        }

        if(numTotalBolos >= numBolosToWin)
        {
            LevelEnd();
        }

        if(actualLevel > maxLevel)
        {
            Victory();
            actualLevel = maxLevel;
        }
    }

    private void LevelEnd()
    {
        nextLevelUI.SetActive(true);

        if(Input.GetKeyDown(KeyCode.Q))
        {
            nextLevelUI.SetActive(false);
            StartCoroutine("NextLevel");
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.1f);        
        _numTotalBolos = 0;
        actualLevel++;
    }

    private void Victory()
    {
        victoryUI.SetActive(true);
        allLevelsEnd = true;

        GiveCoin();
        GiveSecondMarbble();
    }

    private void GiveCoin()
    {
        GlobalVariables.coins++;
        GlobalVariables.canSaveCoin = true;
    }

    private void GiveSecondMarbble()
    {
        if(GlobalVariables.secondMarble = 0)
        {
            GlobalVariables.secondMarble = 1;
            GlobalVariables.canSaveSecondMarble = true;
        }
    }
}
