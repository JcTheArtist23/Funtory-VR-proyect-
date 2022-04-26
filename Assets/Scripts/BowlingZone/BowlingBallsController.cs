using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallsController : MonoBehaviour
{   
    public GameObject[] bowlingBalls;               //Todas las diferentes tipos de bolas de bolas
    public GameObject bowlingBallsParent;           //GameObject (Parent) dónde se genera la bola de bolos
    public Transform generationPosition;            //Posición dónde se genera la bola de bolos

    public static bool areDestroyed;

    private void Start()
    {
        areDestroyed = true;
    }

    private void Update()
    {
        if(areDestroyed == true)
        {
            int n = Random.Range(0, bowlingBalls.Length);
            GameObject ball = Instantiate(bowlingBalls[n], generationPosition.position, bowlingBalls[n].transform.rotation);
            ball.transform.parent = bowlingBallsParent.transform;
            
            areDestroyed = false;
        }
    }
}
