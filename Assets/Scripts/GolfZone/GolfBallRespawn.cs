using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallRespawn : MonoBehaviour
{
    [Space(15)]
    public float respawnX;
    public float respawnY;
    public float respawnZ;
    [Space(15)]
    public bool canSavePosition;

    private float pauseTime;
    private float nextTime;

    private void Start()
    {
        pauseTime = 1f;
        nextTime = 0;
    }

    private void Update()
    {
        if(canSavePosition == true)
        {
            if(Time.time > nextTime)
            {
                nextTime = Time.time + pauseTime;
                        
                float _respawnX = this.gameObject.transform.position.x;
                float _respawnY = this.gameObject.transform.position.y;
                float _respawnZ = this.gameObject.transform.position.z;

                respawnX = _respawnX;
                respawnY = _respawnY;
                respawnZ = _respawnZ;
            }
        }
    }

    private void OnTriggerStay(Collider playing)
    {
        if(playing.gameObject.tag == "playingZone")
        {
            canSavePosition = true;
        }
        else
        {
            canSavePosition = false;
        }
    }

    private void OnTriggerEnter(Collider respawn)
    {
        if(respawn.gameObject.tag == "RespawnZone")
        {
            
        }
    }
}