using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("MARBLES")]
    public GameObject _firstMarble;                 //Posee la primera canica
    public GameObject noFirstMarble;                //No posee la primera canica    
    [Space(15)]
    public GameObject _secondMarble;                //Posee la segunda canica
    public GameObject noSecondMarble;               //No posee la segunda canica

    [Header("COINS")]
    public Text coins;

    private void Update()
    {
        if(GlobalVariables.firstMarble == 1)
        {
            _firstMarble.SetActive(true);
            noFirstMarble.SetActive(false);
        }
        else
        {
            _firstMarble.SetActive(false);
            noFirstMarble.SetActive(true);
        }

        if(GlobalVariables.secondMarble == 1)
        {
            _secondMarble.SetActive(true);
            noSecondMarble.SetActive(false);
        }
        else
        {
            _secondMarble.SetActive(false);
            noSecondMarble.SetActive(true);
        }
    }
}
