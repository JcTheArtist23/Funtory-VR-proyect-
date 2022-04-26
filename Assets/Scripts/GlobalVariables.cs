using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static bool canDeleteKeys;

    [Header("COINS")]
    public static int coins;                //Numero de monedas que tiene el jugador

    [Header("MARBLES")]
    public static int firstMarble;              //0 = No tiene la primera canica / 1 = Tiene la primera canica
    public static int secondMarble;             //0 = No tiene la segunda canica / 1 = Tiene la segunda canica

    [Header("CAN SAVE?")]
    public static bool canSaveCoin;             //Se puede guardar una nueva moneda?
    public static bool canSaveFirstMarble;      //Se puede guardar la primera canica?
    public static bool canSaveSecondMarble;     //Se puede guardar la segunda canica?

    private void Start()
    {
        int _coins = PlayerPrefs.GetInt("COINS", 0);
        coins = _coins;

        int _firstMarble = PlayerPrefs.GetInt("FIRST MARBLE", 0);
        firstMarble = _firstMarble;

        int _secondMarble = PlayerPrefs.GetInt("SECOND MARBLE", 0);
        secondMarble = _secondMarble;
    }

    private void Update()
    {
        Save();
        DeleteSaves();

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Coins = " + coins);
            Debug.Log("FirstMarble = " + firstMarble);
            Debug.Log("SecondMarble = " + secondMarble);
        }
    }

    private void Save()
    {
        if(canSaveCoin == true)
        {
            PlayerPrefs.SetInt("COINS", coins);
            canSaveCoin = false;
        }

        if(canSaveFirstMarble == true)
        {
            PlayerPrefs.SetInt("FIRST MARBLE", firstMarble);
            canSaveFirstMarble = false;
        }

        if(canSaveSecondMarble == true)
        {
            PlayerPrefs.SetInt("SECOND MARBLE", secondMarble);
            canSaveSecondMarble = false;
        }
    }

    private void DeleteSaves()
    {
        if(Input.GetKeyUp(KeyCode.D) && canDeleteKeys == true)
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
