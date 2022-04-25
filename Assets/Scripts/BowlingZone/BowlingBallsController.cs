using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallsController : MonoBehaviour
{
    public GameObject[] bowlingBalls;
    public Transform generationPosition;

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
            Instantiate(bowlingBalls[n], generationPosition.position, bowlingBalls[n].transform.rotation);
            
            areDestroyed = false;
        }
    }
}
