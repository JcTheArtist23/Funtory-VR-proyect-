using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolo : MonoBehaviour
{
    public float destructionTime;               //Tiempo que tarda el bolo en destruirse desde que se ha tumbado
    public bool isSprawled;                     //El bolo se ha tumbado?

    private Rigidbody rbBolo;
    private AudioSource sound;

    private void Awake()
    {
        rbBolo = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        isSprawled = false;
    }

    private void Update()
    {
        if(isSprawled == true)
        {
            isSprawled = false;
            StartCoroutine("DestructionBolos");
        }
    }

    private void OnCollisionEnter(Collision bolo)
    {
        if(bolo.gameObject.tag == "Bolo")
        {
            isSprawled = true;
            sound.Play();
        }
        else if(bolo.gameObject.tag == "BowlingBall")
        {
            isSprawled = true;
            sound.Play();
        }
    }

    private IEnumerator DestructionBolos()
    {
        yield return new WaitForSeconds(destructionTime);
        GameController._numTotalBolos++;
        this.gameObject.SetActive(false);
    }
}
