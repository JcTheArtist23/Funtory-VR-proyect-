using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float generationForce;               //Fuerza que recibe la bola de bolos al generarse para moverse en la máquina bolos
    public float accelerationForce;             //Fuerza que recibe la bola de bolos al estar en la pista de bolos

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
            BowlingBallsGeneration.areDestroyed = true;
        }
    }

    private void OnTriggerStay(Collider accelerator)
    {
        if(accelerator.gameObject.tag == "AccelerationZone")
        {
            rbBall.AddForce(new Vector3(-1, 0, 0) * accelerationForce * Time.deltaTime);
        }
    }
}
