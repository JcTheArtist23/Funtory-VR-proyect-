using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float generationForce;               //Fuerza que recibe la bola de bolos al generarse para moverse en la máquina bolos
    public float accelerationForce;             //Fuerza que recibe la bola de bolos al estar en la pista de bolos
    public float throwForce;                    //Fuerza con la que la bola de bolos sale disparada
    public float gravity;                       //Gravedad que recive la pelota al salir disparada
    public float animTime;                      //Tiempo que dura la animación de la mano
    public bool ballStop;                       //La bola de bolos se teletransporta continuamente junto en la mano?

    private GameObject hand;
    private GameObject ballsParent;
    private Rigidbody rbBall;
    private AudioSource audioBall;

    private void Awake()
    {
        hand = GameObject.Find("GrabController");
        ballsParent = GameObject.Find("BowlingBallsParent");

        rbBall = GetComponent<Rigidbody>();
        audioBall = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ballStop = true;
        rbBall.AddForce(new Vector3(1, 0, 0) * generationForce * Time.deltaTime);
    }

    private void Update()
    {
        if(gameObject.transform.parent != null)
        {
            rbBall.constraints = RigidbodyConstraints.FreezePosition;
            rbBall.constraints = RigidbodyConstraints.FreezeRotation;
            rbBall.useGravity = false;
            
            if(ballStop == true)
            {
                float GBX = hand.transform.position.x;
                float GBY = hand.transform.position.y;
                float GBZ = hand.transform.position.z;
                gameObject.transform.position = new Vector3(GBX, GBY, GBZ);
            }
        }
        ThrowBall();
    }

    private void ThrowBall()
    {
        if(GrabController.throwAct == true)
        {
            ballStop = false;
            rbBall.constraints = RigidbodyConstraints.None;

            StartCoroutine("ThrowTime");
        }
    }

    private IEnumerator ThrowTime()
    {
        yield return new WaitForSeconds(animTime);
        
        rbBall.useGravity = true;        
        gameObject.transform.parent = ballsParent.transform;
        
        rbBall.AddForce(new Vector3(-1, 0, 0) * throwForce * Time.deltaTime);
        rbBall.AddForce(new Vector3(0, -1, 0) * gravity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider ball)
    {
        if(ball.gameObject.tag == "DestructionZone")
        {
            Destroy(this.gameObject);
            BowlingBallsGeneration.areDestroyed = true;
            
            ballStop = true;
            GrabController.throwAct = false;
            GrabController.restartThrow = true;
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
