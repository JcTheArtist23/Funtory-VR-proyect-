using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float generationForce;               //Fuerza que recibe la bola de bolos al generarse para moverse en la máquina bolos
    public float accelerationForce;             //Fuerza que recibe la bola de bolos al estar en la pista de bolos
    private float throwForce = 500f;

    private Rigidbody rbBall;
    private AudioSource audioBall;

    private void Awake()
    {
        rbBall = GetComponent<Rigidbody>();
        audioBall = GetComponent<AudioSource>();
    }

    private void Start()
    {
        rbBall.AddForce(new Vector3(1, 0, 0) * generationForce * Time.deltaTime);
    }

    private void Update()
    {
        if(gameObject.transform.parent != null)
        {
            rbBall.constraints = RigidbodyConstraints.FreezePosition;
            rbBall.constraints = RigidbodyConstraints.FreezeRotation;
            rbBall.useGravity = false;
        }
        else
        {
            rbBall.constraints = RigidbodyConstraints.None;
            rbBall.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider ball)
    {
        if(ball.gameObject.tag == "DestructionZone")
        {
            Destroy(this.gameObject);
            BowlingBallsGeneration.areDestroyed = true;
        }

        if(ball.gameObject.tag == "AccelerationZone")
        {
            audioBall.Play();
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
