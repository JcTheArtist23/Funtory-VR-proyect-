using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public float raycastRange;                  //Rango máximo en que se puede coger la bola de bolos
    public static bool throwAct;                //Se puede disparar la bola de bolos?
    public static bool restartThrow;             //Se puede reiniciar las acciones de el disparo de la bola de bolos?      
    private bool throwAnim;                     //Se puede activar la animación de la mano?

    private GameObject initialPos;
    private GameObject throwPos;
    private Animator anim;

    private void Awake()
    {
        initialPos = GameObject.Find("InitialPosition");
        throwPos = GameObject.Find("ThrowPosition");
    }

    private void Start()
    {
       throwAnim = false;
       throwAct = false;
       restartThrow = false;
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Debug.DrawRay(ray.origin, ray.direction * raycastRange, Color.green); 
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastRange))
        {
            var selection = hit.transform;

            if(selection.CompareTag("BowlingBall"))
            {
                Debug.Log("BowlingBall Detected");
                
                if(Input.GetMouseButtonDown(0))
                {
                    hit.transform.parent = throwPos.transform;

                    float throwPosX = throwPos.transform.position.x;
                    float throwPosY = throwPos.transform.position.y;
                    float throwPosZ = throwPos.transform.position.z;

                    gameObject.transform.position = new Vector3(throwPosX, throwPosY + 10, throwPosZ);

                    throwAnim = true;
                }
            }
        }

        ThrowAnim();
        RestartThrowActions();
    }

    private void ThrowAnim()
    {
        if(throwAnim == true)
        {
            float throwPosX = throwPos.transform.position.x;
            float throwPosY = throwPos.transform.position.y;
            float throwPosZ = throwPos.transform.position.z;

            gameObject.transform.position = new Vector3(throwPosX, throwPosY, throwPosZ);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Animator>().SetBool("canThrow", true);
                //throwAnim = false;
                throwAct = true;
            }
        }
        else
        {
            float initialPosX = initialPos.transform.position.x;
            float initialPosY = initialPos.transform.position.y;
            float initialPosZ = initialPos.transform.position.z;

            gameObject.transform.position = new Vector3(initialPosX, initialPosY, initialPosZ);
        }
    }

    private void RestartThrowActions()
    {
        if(restartThrow == true)
        {
            throwAnim = false;
            GetComponent<Animator>().SetBool("canThrow", false);
            restartThrow = false;
        }
    }
}
