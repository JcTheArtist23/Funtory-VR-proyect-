using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float generationForce;               //Fuerza que recibe la bola de bolos añl generarse para moverse en la máquina

    private Rigidbody rbBall;

    private void Awake()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rbBall.AddForce(new Vector3(1, 0, 0) * generationForce * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider destruction)
    {
        if(destruction.gameObject.tag == "DestructionZone")
        {
            Destroy(this.gameObject);
            BowlingBallsController.areDestroyed = true;
        }
    }
}
