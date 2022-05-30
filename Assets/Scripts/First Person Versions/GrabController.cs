using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public float raycastRange;
    public float throwForce;
    public static bool canThrowBall;

    private GameObject grabParent;

    private void Awake()
    {
        grabParent = GameObject.Find("GrabParent");
    }

    private void Start()
    {
        canThrowBall = false;
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
                    hit.transform.parent = grabParent.transform;

                    float grabX = grabParent.transform.position.x;
                    float grabY = grabParent.transform.position.y;
                    float grabZ = grabParent.transform.position.z;

                    hit.transform.position = new Vector3(grabX, grabY, grabZ);
                    canThrowBall = true;
                }
            }
        }
    }
}