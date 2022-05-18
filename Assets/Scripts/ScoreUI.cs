using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private int totalMarbbles;
    
    public GameObject scoreUI;

    public Text marbblesText;
    public Text coinsText;

    private void Start()
    {
        totalMarbbles = 0;
    }

    private void Update()
    {
        TotalMarbbles();
        UI();
    }

    private void TotalMarbbles()
    {       
        if(GlobalVariables.firstMarble == 1)
        {
            totalMarbbles = 1;

            if(GlobalVariables.secondMarble == 1)
            {
                totalMarbbles = 2;
            }
        }
    }

    private void UI()
    {
        marbblesText.text = totalMarbbles.ToString();
        coinsText.text = GlobalVariables.coins.ToString();
    }
}
