using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallRespawn : MonoBehaviour
{
    public bool canComparePositions;           //Se puede comparar las posiciones
    [Space(15)]
    public Vector3 firstPosition;           //Posición de la pelota en un instante
    public Vector3 secondPosition;          //Posición de la pelota un instante después
    [Space(15)]
    public Vector3 respawnPosition;         //Posición de la pelota al respawnear

    private void Start()
    {
        canComparePositions = true;
    }

    private void Update()
    {
        if(canComparePositions = true)
        {
            canComparePositions = false;
            firstPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            StartCoroutine("SecondPosition");
        }

        if(firstPosition == secondPosition)
        {
            SetRespawnPosition();
        }
        else
        {
            firstPosition = new Vector3(0, 0, 0);
            secondPosition = new Vector3(0, 0, 0);
        }
    }

    private IEnumerator SecondPosition()
    {
        yield return new WaitForSeconds(3);
        secondPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        canComparePositions = true;
    }

    private void SetRespawnPosition()
    {
        respawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void OnTriggerEnter(Collider respawn)
    {
        if(respawn.gameObject.tag == "RespawnZone")
        {
            Respawn();
        }
    }

    private void Respawn()
    {

    }
}