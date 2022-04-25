using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolo : MonoBehaviour
{
    public float destructionTime;
    public bool isSprawled;

    private Rigidbody rbBolo;

    private void Awake()
    {
        rbBolo = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        isSprawled = false;
    }

    private void Update()
    {
        if(isSprawled == true)
        {
            StartCoroutine("DestructionBolos");
        }
    }

    private void OnCollisionEnter(Collision bolo)
    {
        if(bolo.gameObject.tag == "Bolo")
        {
            isSprawled = true;
        }
        else if(bolo.gameObject.tag == "Bola de Bolos")
        {
            isSprawled = true;
        }
    }

    private IEnumerator DestructionBolos()
    {
        yield return new WaitForSeconds(destructionTime);
        this.gameObject.SetActive(false);
        GameController._numTotalBolos++;
    }
}
