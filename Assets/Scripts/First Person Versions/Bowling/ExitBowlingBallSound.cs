using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBowlingBallSound : MonoBehaviour
{
    public GameObject bowlingBall;
    private AudioSource audioExit;

    private void Awake()
    {
        audioExit = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(bowlingBall.transform.parent != null)
        {
            audioExit.Stop();
        }
    }

    private void OnTriggerEnter(Collider sound)
    {
        if(sound.gameObject.tag == "StopSound")
        {
            audioExit.Stop();
        }
    }
}
