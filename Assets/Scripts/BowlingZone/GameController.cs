using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("VICTORY")]
    public static int _numTotalBolos;       //Número de bolos tirados
    public int numTotalBolos;               //Número de bolos tirados

    public int numBolosToWin1;              //Número de bolos totales para tirar y obtener la victoria en el nivel 1
    public int numBolosToWin2;              //Número de bolos totales para tirar y obtener la victoria en el nivel 2
    public int numBolosToWin3;              //Número de bolos totales para tirar y obtener la victoria en el nivel 3
    public int numBolosToWin4;              //Número de bolos totales para tirar y obtener la victoria en el nivel 4
    public int numBolosToWin5;              //Número de bolos totales para tirar y obtener la victoria en el nivel 5
    private int numBolosToWin;              //Número de bolos totales para tirar y obtener la victoria en los niveles
    
    public GameObject victoryUI;            //UI que aparece al ganar

    [Header("BOWLING GAMEOBJECTS")]
    public GameObject level1;               //Nivel de bolos 1
    public GameObject level2;               //Nivel de bolos 2
    public GameObject level3;               //Nivel de bolos 3
    public GameObject level4;               //Nivel de bolos 4
    public GameObject level5;               //Nivel de bolos 5

    [Header("BOWLING LEVELS")]
    public int actualLevel;                 //Nivel en el que el jugador se encuentra jugando
    public int maxLevel;                    //Nivel máximo de bolos
    public float passLevelTime;             //Tiempo entre la victoria de un nivel y el inicio del siguiente

    private void Start()
    {
        actualLevel = 1;
    }

    private void Update()
    {
        numTotalBolos = _numTotalBolos;

        if(actualLevel == 1)
        {
            numBolosToWin = numBolosToWin1;
        }
        if(actualLevel == 2)
        {
            numBolosToWin = numBolosToWin2;
        }
        if(actualLevel == 3)
        {
            numBolosToWin = numBolosToWin3;
        }
        if(actualLevel == 4)
        {
            numBolosToWin = numBolosToWin4;
        }
        if(actualLevel == 5)
        {
            numBolosToWin = numBolosToWin5;
        }

        if(numTotalBolos == numBolosToWin)
        {
            Victory();
        }
    }

    private void Victory()
    {
        victoryUI.SetActive(true);
        StartCoroutine("NextLevel");
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(passLevelTime);

        victoryUI.SetActive(false);
        actualLevel++;
        _numTotalBolos = 0;

        if(actualLevel >= maxLevel)
        {
            
        }
    }
}
