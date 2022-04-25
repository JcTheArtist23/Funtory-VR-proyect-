using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    private Rigidbody rbBall;

    private void Awake()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }

    private void OnCollisionEnter(Collision destruction)
    {
        if(destruction.gameObject.tag == "DestructionZone")
        {
            Destroy(this.gameObject);
            BowlingBallsController.areDestroyed = true;
        }
    }
}
